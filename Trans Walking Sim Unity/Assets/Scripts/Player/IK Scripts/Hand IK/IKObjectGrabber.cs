using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Animator))]
public class IKObjectGrabber : MonoBehaviour
{
    public static bool ikActive = false;

    [SerializeField] Rig rightHandRig;
    [SerializeField] float rigLerpingTime = 0.5f;

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            ikActive = !ikActive;
        }

        IncreaseRigWeight();
    }

    private void IncreaseRigWeight() {
        if (ikActive && CanHoldObject.canHoldObject) {
            rightHandRig.weight = Mathf.Lerp(rightHandRig.weight, 1, Time.deltaTime * rigLerpingTime);
        }
        else {
            rightHandRig.weight = Mathf.Lerp(rightHandRig.weight, 0, Time.deltaTime * rigLerpingTime);
        }
    }
}