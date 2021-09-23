using UnityEngine;
using Febucci.UI;

public class ThinkingTextEnabled : MonoBehaviour
{
    private TextAnimatorPlayer textAnimatorPlayer;
    private PlayerObjectInteractor objectInteractor;

    private void Start() {
        textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();
        objectInteractor = FindObjectOfType<PlayerObjectInteractor>();

        textAnimatorPlayer.ShowText(objectInteractor.currentObject.backStory);
    }
}