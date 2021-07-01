using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKFootPlacement : MonoBehaviour
{
    [Range(0, 1f)] [SerializeField] float distanceToGround;
    [SerializeField] LayerMask affectLayers; // Select everything and then unselect the player layer

    private Animator animator;

    void Start() => animator = GetComponent<Animator>();

    private void OnAnimatorIK(int layerIndex) {
        if (animator) {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, animator.GetFloat("IKLeftFootWeight"));
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, animator.GetFloat("IKRightFootWeight"));


            // Left foot
            RaycastHit hit;
            Ray ray = new Ray(animator.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);

            if (Physics.Raycast(ray, out hit, distanceToGround + 1f, affectLayers)) {
                if (hit.transform.tag == "Ground") {
                    Vector3 footPos = hit.point;
                    footPos.y += distanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.LeftFoot, footPos);

                    animator.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation);
                }
            }


            // Right foot
            ray = new Ray(animator.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);

            if (Physics.Raycast(ray, out hit, distanceToGround + 1f, affectLayers)) {
                if (hit.transform.tag == "Ground") {
                    Vector3 footPos = hit.point;
                    footPos.y += distanceToGround;
                    animator.SetIKPosition(AvatarIKGoal.RightFoot, footPos);

                    animator.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation);
                }
            }
        }
    }
}