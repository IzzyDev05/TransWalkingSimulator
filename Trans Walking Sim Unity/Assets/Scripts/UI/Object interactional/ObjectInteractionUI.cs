using UnityEngine;

public class ObjectInteractionUI : MonoBehaviour
{
    [SerializeField] GameObject objectCanvas;
    [SerializeField] GameObject textPanel;
    [SerializeField] GameObject thinkingText;

    private bool textInstantiated = false;
    private GameObject instantiatedTextObject;
    private PlayerObjectInteractor objectInteractor;

    private void Start() {
        objectCanvas.SetActive(false);
        objectInteractor = FindObjectOfType<PlayerObjectInteractor>();
    }

    private void Update() {
        if (PlayerObjectInteractor.ShowInteractionUI) {
            objectCanvas.SetActive(true);
            thinkingText.SetActive(true);

            if (!textInstantiated) {
                InstantiateText();
            }
        }
        else {
            objectCanvas.SetActive(false);
            thinkingText.SetActive(false);

            DestoryText();
        }

        if (Input.GetMouseButtonDown(1)) {
            PlayerObjectInteractor.ShowInteractionUI = false;
            DestoryText();
        }
    }

    private void InstantiateText() {
        instantiatedTextObject = Instantiate(thinkingText, textPanel.transform);
        textInstantiated = true;
    }

    private void DestoryText() {
        textInstantiated = false;
        Destroy(instantiatedTextObject);
    }
}