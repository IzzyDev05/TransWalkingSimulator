using UnityEngine;

public class PlayerDialogueController : MonoBehaviour
{
    [SerializeField] bool isNPC = false;

    private GameObject npc;
    private Animator animator;
    private Animator npcAnimator;
    private MouseLook mouseLook;

    private void Start() {
        mouseLook = FindObjectOfType<MouseLook>();
        animator = GetComponent<Animator>();

        if (isNPC) {
            npc = GameObject.FindGameObjectWithTag("NPC");
            npcAnimator = npc.GetComponent<Animator>();
        }
    }

    private void Update() {
        HandleDialogueCanvas();
    }

    private void HandleDialogueCanvas() {
        if (DialogueController.dialogueCanvasEnabled) {
            mouseLook.GetComponent<MouseLook>().enabled = false;
            animator.enabled = false;
            if (npcAnimator) {
                npcAnimator.SetBool("isTalking", true);
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else {
            mouseLook.GetComponent<MouseLook>().enabled = true;
            animator.enabled = true;
            if (npcAnimator) {
                npcAnimator.SetBool("isTalking", false);
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }
    }
}