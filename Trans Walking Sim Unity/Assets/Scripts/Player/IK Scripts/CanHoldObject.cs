using UnityEngine;

public class CanHoldObject : MonoBehaviour
{
    [HideInInspector] public Transform objectToHold;

    private IKObjectGrabber objectGrabber;

    private void Start() {
        objectGrabber = FindObjectOfType<IKObjectGrabber>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "ObjectGrabber") {
            objectGrabber.objectInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "ObjectGrabber") {
            objectGrabber.objectInRange = false;
            objectToHold = null;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "ObjectGrabber") {
            objectToHold = other.gameObject.transform;
        }
    }
}