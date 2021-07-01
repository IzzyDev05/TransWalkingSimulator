using UnityEngine;

public class CanLookAtObject : MonoBehaviour
{
    [HideInInspector] public Transform objectToLookAt;

    private IKObjectGrabber objectGrabber;

    private void Start() {
        objectGrabber = FindObjectOfType<IKObjectGrabber>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "HoldableObject") {
            objectGrabber.canLookAtObject = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "HoldableObject") {
            objectGrabber.canLookAtObject = false;
            objectToLookAt = null;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "HoldableObject") {
            objectToLookAt = other.gameObject.transform;
        }
    }
}