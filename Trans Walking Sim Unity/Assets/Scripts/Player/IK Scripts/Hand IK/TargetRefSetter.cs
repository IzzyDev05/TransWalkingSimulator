using UnityEngine;
using System.Collections;

public class TargetRefSetter : MonoBehaviour
{
    [SerializeField] Transform handRef;
    [SerializeField] Transform targetRef = null;
    [SerializeField] Transform handOriginalPos; 

    private ObjectFinder objectFinder;

    private void Start() {
        objectFinder = FindObjectOfType<ObjectFinder>();
    }

    private void Update() {
        if (CanHoldObject.canHoldObject) {
            targetRef = objectFinder.targetGameObject.transform;
            
            handRef.position = targetRef.position;
            handRef.rotation = targetRef.rotation;
        }
        else {
            targetRef = null;

            handRef.position = handOriginalPos.position;
            handRef.rotation = handOriginalPos.rotation;
        }
    }
}