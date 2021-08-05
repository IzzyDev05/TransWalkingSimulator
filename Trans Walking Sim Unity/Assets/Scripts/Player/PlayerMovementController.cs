using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    [Header("Animation speeds")]
    [SerializeField] float forwardAccelaration = 7.5f;
    [SerializeField] float forwardDecelaration = 2.5f;
    [SerializeField] float sideAccelaration = 7.5f;
    [SerializeField] float sideDecelaration = 2.5f;

    private int velocityZHash;
    private int velocityXHash;
    private float velocityZ = 0.0f;
    private float velocityX = 0.0f;

    private GameObject npc;
    private Animator npcAnimator;
    private Animator animator;
    private MouseLook mouseLook;

    private void Start() {
        animator = GetComponent<Animator>();

        npc = GameObject.FindGameObjectWithTag("NPC");
        npcAnimator = npc.GetComponent<Animator>();

        mouseLook = FindObjectOfType<MouseLook>();

        velocityZHash = Animator.StringToHash("velocityZ");
        velocityXHash = Animator.StringToHash("velocityX");
    }

    private void Update() {
        HandleDialogueCanvas();
        GetInput();
    }

    private void HandleDialogueCanvas() {
        if (DialogueController.dialogueCanvasEnabled) {
            mouseLook.GetComponent<MouseLook>().enabled = false;
            animator.enabled = false;
            npcAnimator.SetBool("isTalking", true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else {
            mouseLook.GetComponent<MouseLook>().enabled = true;
            animator.enabled = true;
            npcAnimator.SetBool("isTalking", false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void GetInput() {
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        HandleMovement();
        HandleVelocities(forwardPressed, leftPressed, rightPressed);

        transform.eulerAngles = new Vector3(0f, mouseLook.yaw, 0f);

        animator.SetFloat(velocityZHash, velocityZ);
        animator.SetFloat(velocityXHash, velocityX);
    }

    private void HandleMovement() {
        // Reading the input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Moving
        if (movement.magnitude > 0) {
            movement.Normalize();
            movement *= speed * Time.deltaTime;
            //forwardObject.Translate(movement);
            transform.Translate(movement);
        }

        if (Input.GetKey(KeyCode.S)) {
            animator.SetBool("walkingBackwards", true);
        }
        if (!Input.GetKey(KeyCode.S)) {
            animator.SetBool("walkingBackwards", false);
        }
    }

    private void HandleVelocities(bool forwardPressed, bool leftPressed, bool rightPressed) {
        // Forward movement, stopping and resetting
        if (forwardPressed && velocityZ < 1.0f) {
            velocityZ += Time.deltaTime * forwardAccelaration;
        }
        if (!forwardPressed && velocityZ > 0.0f) {
            velocityZ -= Time.deltaTime * forwardDecelaration;
        }
        if (!forwardPressed && velocityZ < 0.0f) {
            velocityZ = 0.0f;
        }

        // Left movement and stopping 
        if (leftPressed && velocityX > -1.0f) {
            velocityX -= Time.deltaTime * sideAccelaration;
        }
        if (!leftPressed && velocityX < 0.0f) {
            velocityX += Time.deltaTime * sideDecelaration;
        }

        // Right movement and stopping
        if (rightPressed && velocityX < 1.0f) {
            velocityX += Time.deltaTime * sideAccelaration;
        }
        if (!rightPressed && velocityX > 0.0f) {
            velocityX -= Time.deltaTime * sideDecelaration;
        }

        // Left and right resetting
        if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > 0.1f && velocityX < 0.1f)) {
            velocityX = 0.0f;
        }
    }
}