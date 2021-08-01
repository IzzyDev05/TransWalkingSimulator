using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTextObject : MonoBehaviour
{
    [SerializeField] TMP_Text myText;

    public void Setup(string newDialogue) {
        myText.text = newDialogue;
    }
}