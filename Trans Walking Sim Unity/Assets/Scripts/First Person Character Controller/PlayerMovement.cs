using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 8;
    [SerializeField] float runSpeed = 12;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject mouseLook;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;

    private Vector3 velocity;
    private bool isGrounded;

    private void Update() {
        Movement();
        Jump();

        if (DialogueController.dialogueCanvasEnabled) {
            mouseLook.GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else {
            mouseLook.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift)) {
            controller.Move(move * runSpeed * Time.deltaTime);
        }
        else {
            controller.Move(move * walkSpeed * Time.deltaTime);
        }
    }

    private void Jump() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}