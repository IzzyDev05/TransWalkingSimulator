using UnityEngine;

public class CanHoldObject : MonoBehaviour
{
    public static bool canHoldObject;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "HoldableRegion") {
            canHoldObject = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        canHoldObject = false;
    }
}