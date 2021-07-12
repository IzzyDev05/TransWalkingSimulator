using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class IKObjectGrabber : MonoBehaviour
{
    [HideInInspector] public bool objectInRange = false;
    [HideInInspector] public bool ikActive = false;

    [SerializeField] Transform holdableObjectParent;
    [SerializeField] float reactionTime = 0.5f;

    private float state = 0f;
    private float elapsedTime = 0f;

    private Transform rightHandObj = null;
    private CanHoldObject objectHoldScript;
    private Animator animator;

    private void Start() {
        animator = GetComponentInParent<Animator>();
        state = 0;
        objectHoldScript = FindObjectOfType<CanHoldObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            ikActive = !ikActive;
        }
    }

    private void OnAnimatorIK() {
        if (animator) {
            HoldObject();
        }
    }   

    private GameObject GetMainObject() {
        GameObject mainObject = rightHandObj.transform.parent.gameObject;

        if (mainObject != null) {
            return mainObject;
        }
        else {
            return null;
        }
    }

    /*
    private void HoldObject() {
        if (ikActive) {
            if (rightHandObj != null && objectInRange) {
                if (state < 1.0f) {
                    elapsedTime += Time.deltaTime;
                    state = Mathf.Lerp(0, 1, elapsedTime / reactionTime);
                }
                else {
                    state = 1.0f;
                    elapsedTime = 0;
                }

                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, state);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, state);

                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                GameObject mainObject = GetMainObject();

                if (mainObject.tag != "Immovable") {
                    mainObject.transform.parent = holdableObjectParent;
                }
                if (mainObject.GetComponent<Rigidbody>()) {
                    mainObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        else {
            if (state > 0f) {
                elapsedTime += Time.deltaTime;
                state = Mathf.Lerp(0, 1, elapsedTime / reactionTime);
                state = 1 - state;

                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, state);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, state);

                if (rightHandObj != null) {
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                    GameObject mainObject = GetMainObject();

                    if (mainObject.tag != "Immovable") {
                        mainObject.transform.parent = null;
                    }
                    if (mainObject.GetComponent<Rigidbody>()) {
                        mainObject.GetComponent<Rigidbody>().isKinematic = false;
                    }
                }
            }
            else {
                state = 0;
                elapsedTime = 0;
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);

                animator.SetLookAtWeight(0f);
            }
        }
    }
    */

    private void HoldObject() {
        if (ikActive) {
            if (objectInRange) {
                rightHandObj = objectHoldScript.objectToHold;
            }
            else {
                rightHandObj = null;
            }

            if (rightHandObj != null) {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);

                GameObject mainObject = GetMainObject();
                mainObject.transform.parent = holdableObjectParent;
            }
        }
        else {
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

            GameObject mainObject = GetMainObject();
            mainObject.transform.parent = null;
        }
    }
}