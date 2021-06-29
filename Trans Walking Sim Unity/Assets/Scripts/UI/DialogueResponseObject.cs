using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueResponseObject : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    private int choiceValue;

    public void Setup(string newDialogue, int myChoice) {
        myText.text = newDialogue;
        choiceValue = myChoice;
    }
}