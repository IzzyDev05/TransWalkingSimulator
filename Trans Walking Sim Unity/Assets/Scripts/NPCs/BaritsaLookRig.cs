using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BaritsaLookRig : MonoBehaviour
{
    [SerializeField] Rig headRig;
    [SerializeField] Rig chestRig;
    [SerializeField] float lerpingTime = 0.5f;

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            headRig.weight = Mathf.Lerp(headRig.weight, 1, Time.deltaTime * lerpingTime);
            chestRig.weight = Mathf.Lerp(chestRig.weight, 0.7f, Time.deltaTime * lerpingTime);
        }
        else {
            headRig.weight = Mathf.Lerp(headRig.weight, 0, Time.deltaTime * lerpingTime);
            chestRig.weight = Mathf.Lerp(chestRig.weight, 0, Time.deltaTime * lerpingTime);
        }
    }
}
