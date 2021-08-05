using UnityEngine;
using System.Collections;

public class HandleCoffeChoice : MonoBehaviour
{
    [SerializeField] GameObject takeAwayCup;
    [SerializeField] GameObject hotCocoMug;

    private DialogueController dialogueController;

    private void Start() {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    public void HandleCupChoice() {
        object showTakeAwayCup = dialogueController.myStory.variablesState["takeAwayCup"];
        object showHotCocoMug = dialogueController.myStory.variablesState["hotCoco"];

        TakeAwayCup(showTakeAwayCup);
        HotCocoMug(showHotCocoMug);
    }

    private void TakeAwayCup(object showTakeAwayCup) {
        bool shouldShowTakeAwayCup = false;

        if (showTakeAwayCup is bool) {
            shouldShowTakeAwayCup = (bool)showTakeAwayCup;
        }
        else {
            shouldShowTakeAwayCup = false;
        }

        if (shouldShowTakeAwayCup) {
            takeAwayCup.SetActive(true);
        }
        else {
            takeAwayCup.SetActive(false);
        }
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