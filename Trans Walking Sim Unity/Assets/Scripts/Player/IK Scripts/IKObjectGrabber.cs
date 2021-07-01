using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKObjectGrabber : MonoBehaviour
{
    [HideInInspector] public bool objectInRange = false;
    [HideInInspector] public bool canLookAtObject = false;

    [SerializeField] bool ikActive = false;

    private Transform lookObj = null;
    private Transform rightHandObj = null;

    private CanLookAtObject objectLookScript;
    private CanHoldObject objectHoldScript;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        objectLookScript = FindObjectOfType<CanLookAtObject>();
        objectHoldScript = FindObjectOfType<CanHoldObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            ikActive = !ikActive;
        }
    }

    private void OnAnimatorIK(int layerIndex) {
        if (animator) {
            if (ikActive) {
                // Attach the objects
                AttachObjectTransforms();

                // Set the look target position, if one has been assigned
                if (lookObj != null && canLookAtObject) {
                    animator.SetLookAtWeight(1f);
                    animator.SetLookAtPosition(lookObj.position);
                }

                // Set the right hand position and rotation, if one has been assigned
                if (rightHandObj != null && objectInRange) {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
                    animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
                }
            }
            else {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
                animator.SetLookAtWeight(0f);
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