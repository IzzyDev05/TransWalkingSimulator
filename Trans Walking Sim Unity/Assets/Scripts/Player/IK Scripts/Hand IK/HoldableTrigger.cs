using UnityEngine;

public class HoldableTrigger : MonoBehaviour
{
    [SerializeField] GameObject parentObject;

    private void Update() {
        gameObject.transform.rotation = parentObject.transform.rotation;
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "PlayerHandRegion") {
            this.gameObject.transform.parent = parentObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        this.gameObject.transform.parent = null;
    }
}