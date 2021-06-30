using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class DialogueController : MonoBehaviour
{
    public static bool dialogueCanvasEnabled = false;

    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] GameObject dialoguePrefab;
    [SerializeField] GameObject choicePrefab;
    [SerializeField] GameObject dialougeHolder;
    [SerializeField] GameObject choiceHolder;
    [SerializeField] GameObject chocolateBar;
    [SerializeField] TextAssetValue dialogueValue;
    [SerializeField] Story myStory;

    private bool showChocolate;

    public void EnableCanvas() {
        dialogueCanvas.SetActive(true);
        SetStory();
        RefreshView();
        dialogueCanvasEnabled = true;
    }

    public void DisableCanvas() {
        dialogueCanvas.SetActive(false);
        dialogueCanvasEnabled = false;
    }

    public void SetStory() {
        if (dialogueValue.value) {
            DeleteOldDialogues();
            myStory = new Story(dialogueValue.value.text);
        }
        else {
            Debug.LogWarning("Something went wrong with the story setup!");
        }
    }

    private void DeleteOldDialogues() {
        for (int i = 0; i < dialougeHolder.transform.childCount; i++) {
            Destroy(dialougeHolder.transform.GetChild(i).gameObject);
        }
    }

    public void RefreshView() {
        while (myStory.canContinue) {
            ShowChocolateBar();
            MakeNewDialogue(myStory.Continue());
        }
        if (myStory.currentChoices.Count > 0) {
            MakeNewChoices();
        }
        else {
            DisableCanvas();
        }
    }

    private void MakeNewDialogue(string newDialogue) {
        for (int i = 0; i < dialougeHolder.transform.childCount; i++) {
            Destroy(dialougeHolder.transform.GetChild(i).gameObject);
        }

        DialogueTextObject newDialogueTextObject = Instantiate(dialoguePrefab, dialougeHolder.transform).GetComponent<DialogueTextObject>();
        newDialogueTextObject.Setup(newDialogue);
    }

    private void MakeNewChoices() {
        for (int i = 0; i < choiceHolder.transform.childCount; i++) {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < myStory.currentChoices.Count; i++) {
            MakeNewResponse(myStory.currentChoices[i].text, i);
        }
    }

    private void MakeNewResponse(string newDialogue, int choiceValue) {
        DialogueResponseObject newDialogueResponseObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<DialogueResponseObject>();
        newDialogueResponseObject.Setup(newDialogue, choiceValue);

        Button responseButton = newDialogueResponseObject.gameObject.GetComponent<Button>();
        if (responseButton) {
            responseButton.onClick.AddListener(delegate { ChooseChoice(choiceValue);  });
        }
    }

    private void ChooseChoice(int choice) {
        myStory.ChooseChoiceIndex(choice);
        RefreshView();
    }

    private void ShowChocolateBar() {
        object showChocolate = myStory.variablesState["showChocolate"];
        bool shouldShowChocolate = false;

        if (showChocolate is bool) {
            shouldShowChocolate = (bool)showChocolate;
        }
        else {
            shouldShowChocolate = false;
        }

        if (shouldShowChocolate) {
            chocolateBar.SetActive(true);
        }
        else {
            chocolateBar.SetActive(false);
        }
    }
}