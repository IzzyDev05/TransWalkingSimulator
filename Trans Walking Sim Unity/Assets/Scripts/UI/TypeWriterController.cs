using UnityEngine;
using Febucci.UI;
using System.Collections;

public class TypeWriterController : MonoBehaviour
{
    [SerializeField] bool isForOptions = false;
    [SerializeField] float disableTime = 0.015f;

    private GameObject choicePanel;
    private TextAnimatorPlayer textAnimatorPlayer;
    private Animator[] animArray;

    private void Start() {
        choicePanel = GameObject.FindGameObjectWithTag("choicePanel");
        textAnimatorPlayer = GetComponent<TextAnimatorPlayer>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            textAnimatorPlayer.SkipTypewriter();
        }

        if (isForOptions) {
            if (choicePanel) {
                animArray = choicePanel.GetComponentsInChildren<Animator>();
            }
            else {
                Debug.LogWarning("Choice panel was not found!");
                return;
            }
        }
    }

    public void DisableAnimator() {
        if (choicePanel) {
            StartCoroutine(WaitBeforeDisable());
        }
    }

    public void EnableAnimtor() {
        if (choicePanel) {
            foreach (Animator anim in animArray) {
                anim.enabled = true;
            }
        }
    }

    private IEnumerator WaitBeforeDisable() {
        yield return new WaitForSeconds(disableTime);

        Animator[] tempAnimArray = animArray;
        foreach (Animator anim in tempAnimArray) {
            anim.enabled = false;
        }
    }
}