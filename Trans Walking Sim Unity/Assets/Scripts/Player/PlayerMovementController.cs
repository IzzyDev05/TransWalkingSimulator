using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] LayerMask aimLayerMask;

    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Update() {
        //AimTowardsMouse();

        // Reading the input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Moving
        if (movement.magnitude > 0) {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        // Animating
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);

        // Clamping
        velocityZ = Mathf.Clamp(velocityZ, -0.707f, 0.707f);
        velocityX = Mathf.Clamp(velocityX, -0.707f, 0.707f);

        animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }

    private void AimTowardsMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, aimLayerMask)) {
            var direction = hitInfo.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = direction;
        }
    }
}