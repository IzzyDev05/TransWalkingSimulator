using UnityEngine;
using System.Collections;

public class ObjectFinder : MonoBehaviour
{
    public Transform targetGameObject = null; 

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "HoldableObject") {
            targetGameObject = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        targetGameObject = null;
    }
}