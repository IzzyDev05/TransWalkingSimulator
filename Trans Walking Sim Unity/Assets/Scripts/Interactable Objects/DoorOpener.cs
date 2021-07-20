using System.Collections;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] float doorAnimWaitTime = 1f;
    [SerializeField] Animator animatorObject;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "HoldableRegion") {
            CanHoldObject.canHoldObject = true;
            StartCoroutine(OpenDoorAnimation());
        }
    }

    private IEnumerator OpenDoorAnimation() {
        if (IKObjectGrabber.ikActive) {
            yield return new WaitForSeconds(doorAnimWaitTime);
            animatorObject.enabled = true;
        }
        else {
            yield return new WaitForSeconds(0.001f);
        }
    }

    private void OnTriggerExit(Collider other) {
        CanHoldObject.canHoldObject = false;
    }
}