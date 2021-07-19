using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    /*
    [SerializeField] float doorAnimWaitTime = 1f;
    [SerializeField] Animator doorParentAnim;

    private IKObjectGrabber objectGrabber;

    private void Start() {
        objectGrabber = FindObjectOfType<IKObjectGrabber>();
        doorParentAnim.enabled = false;
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "PlayerHandRegion") {
            StartCoroutine(OpenDoorAnimation());
        }
    }

    private IEnumerator OpenDoorAnimation() {
        if (objectGrabber.ikActive) {
            yield return new WaitForSeconds(doorAnimWaitTime);
            doorParentAnim.enabled = true;
        }
        else {
            yield return new WaitForSeconds(0.001f);
        }
    }
    */
}