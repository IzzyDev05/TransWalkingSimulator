using UnityEngine;
using TMPro;
using Febucci.UI;

public class DialogueTextObject : MonoBehaviour
{
    [SerializeField] TMP_Text myText;
    [SerializeField] TextAnimatorPlayer textAnimatorPlayer;

    public void Setup(string newDialogue) {
        //myText.text = newDialogue;
        textAnimatorPlayer.ShowText(newDialogue);
    }
}