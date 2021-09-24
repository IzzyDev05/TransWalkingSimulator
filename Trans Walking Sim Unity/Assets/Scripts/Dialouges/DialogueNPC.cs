using UnityEngine;

public class DialogueNPC : MonoBehaviour
{
    [SerializeField] TextAssetValue dialogueValue;
    [SerializeField] TextAsset myDialogue;

    private bool playerInRange = false;
    private DialogueController dialogueController;

    private void Start() {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    private void Update() {
        HandleDialogueUI();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerInRange = false;
            dialogueController.DisableCanvas();
        }
    }

    private void HandleDialogueUI() {
        if (playerInRange && Input.GetButtonDown("ActionKey")) {
            dialogueValue.value = myDialogue;
            dialogueController.EnableCanvas();
        }
    }
}