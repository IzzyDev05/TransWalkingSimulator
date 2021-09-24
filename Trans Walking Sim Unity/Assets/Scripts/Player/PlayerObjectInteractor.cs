using UnityEngine;

public class PlayerObjectInteractor : MonoBehaviour
{
    public static bool ShowInteractionUI = false;

    [HideInInspector] public InteractableObjectInfo currentObject;

    [Header("Game objects")]
    [SerializeField] InteractableObjectInfo[] objectInfo;
    [SerializeField] GameObject interactionKeyUI;

    [Header("Raycast variables")]
    [SerializeField] Transform rayPos;
    [SerializeField] LayerMask objectLayer;
    [SerializeField] float rayDistance;

    private ObjectIdentification checkedObject;

    private void Start() {
        interactionKeyUI.SetActive(false);
    }

    private void Update() {
        if (Input.GetButtonDown("ActionKey")) {
            InteractWithObject();
        }

        Raycast();
        HandleUI();
    }

    private void Raycast() {
        RaycastHit hit;

        if (Physics.Raycast(rayPos.position, Camera.main.transform.forward, out hit, rayDistance, objectLayer)) {
            if (hit.collider.GetComponent<ObjectType>()) {
                checkedObject = hit.collider.GetComponent<ObjectType>().objectType;
            }
        }
        else {
            checkedObject = ObjectIdentification.None;
            currentObject = null;
            ShowInteractionUI = false;
        }
    }

    private void InteractWithObject() {
        ObjectLocator();

        if (currentObject) {
            ShowInteractionUI = true;
        }
        else {
            ShowInteractionUI = false;
        }
    }

    private void ObjectLocator() {
        foreach (InteractableObjectInfo info in objectInfo) {
            if (info.objectIdentification == checkedObject) {
                currentObject = info;
            }
            else {
                continue;
            }
        }
    }

    private void HandleUI() {
        if (!ShowInteractionUI && checkedObject != ObjectIdentification.None) {
            interactionKeyUI.SetActive(true);
        }
        else {
            interactionKeyUI.SetActive(false);
        }
    }
}