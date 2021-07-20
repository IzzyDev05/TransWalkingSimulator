using UnityEngine;
using System.Collections;

public class CoffeeCup : MonoBehaviour
{
    [SerializeField] GameObject coffeeCup;
    
    private bool showCoffeeCup;
    private DialogueController dialogueController;

    private void Start() {
        dialogueController = FindObjectOfType<DialogueController>();
    }

    public void ShowCoffeeCup() {
        object showCoffeCup = dialogueController.myStory.variablesState["showCoffeeCup"];
        bool shouldShowCoffeeCup = false;

        if (showCoffeCup is bool) {
            shouldShowCoffeeCup = (bool)showCoffeCup;
        }
        else {
            shouldShowCoffeeCup = false;
        }

        if (shouldShowCoffeeCup) {
            coffeeCup.SetActive(true);
        }
        else {
            coffeeCup.SetActive(false);
        }
    }
}