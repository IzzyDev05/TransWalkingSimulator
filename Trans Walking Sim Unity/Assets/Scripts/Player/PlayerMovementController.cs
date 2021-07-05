using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform forwardObject;

    private Animator animator;

    private void Awake() {
        animator = GetComponentInParent<Animator>();
    }

    private void Update() {
        // Reading the input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Moving
        if (movement.magnitude > 0) {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            forwardObject.Translate(movement);
        }
        
        // Animating
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        // Clamping
        velocityZ = Mathf.Clamp(velocityZ, -0.707f, 0.707f);
        velocityX = Mathf.Clamp(velocityX, -0.707f, 0.707f);

        animator.SetFloat("VelocityZ", velocityZ, 0.05f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.05f, Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(forwardObject.position, forwardObject.forward * 10);
    }
}