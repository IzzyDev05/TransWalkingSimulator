using UnityEngine;
using System.Collections;

public class HandleCoffeChoice : MonoBehaviour
{
    [SerializeField] GameObject hotCocoMug;

    private DialogueController dialogueController;

    private void Start() {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    public void HandleCupChoice() {
        object showHotCocoMug = dialogueController.myStory.variablesState["hotCoco"];
        HotCocoMug(showHotCocoMug);
    }

    private void HotCocoMug(object showHotCocoMug) {
        bool shouldShowHotCocoMug = false;

        if (showHotCocoMug is bool) {
            shouldShowHotCocoMug = (bool)showHotCocoMug;
        }
        else {
            shouldShowHotCocoMug = false;
        }

        if (shouldShowHotCocoMug) {
            hotCocoMug.SetActive(true);
        }
        else {
            hotCocoMug.SetActive(false);
        }
    }
}