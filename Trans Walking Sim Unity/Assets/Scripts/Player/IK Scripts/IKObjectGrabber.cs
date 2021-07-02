﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKObjectGrabber : MonoBehaviour
{
    [HideInInspector] public bool objectInRange = false;
    [HideInInspector] public bool canLookAtObject = false;

    
    [SerializeField] float reactionTime = 0.5f;

    private Transform lookObj = null;
    private Transform rightHandObj = null;

    private bool playerShouldHoldObject = false;
    private float state = 0f;
    private float elapsedTime = 0f;

    private CanLookAtObject objectLookScript;
    private CanHoldObject objectHoldScript;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        state = 0;
        objectLookScript = FindObjectOfType<CanLookAtObject>();
        objectHoldScript = FindObjectOfType<CanHoldObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            playerShouldHoldObject = !playerShouldHoldObject;
        }
    }

    private void OnAnimatorIK() {
        if (animator) {
            // Attach the objects
            AttachObjectTransforms();

            // Set the look target position, if one has been assigned
            if (lookObj != null && canLookAtObject) {
                animator.SetLookAtWeight(1f);
                animator.SetLookAtPosition(lookObj.position);
            }

            // Set the right hand position and rotation, if one has been assigned
            if (playerShouldHoldObject) {
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
                }
            }
            else {
                if (state > 0f) {
                    elapsedTime += Time.deltaTime;
                    state = Mathf.Lerp(0, 1, elapsedTime / reactionTime);
                    state = 1 - state;

                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, state);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, state);

                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
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
    }

    private void AttachObjectTransforms() {
        // Attach the look at object
        if (canLookAtObject) {
            lookObj = objectLookScript.objectToLookAt;
        }

        // Attach the grabbing object
        if (objectInRange) {
            rightHandObj = objectHoldScript.objectToHold;
        }
    }
}