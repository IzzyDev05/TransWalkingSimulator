using UnityEngine;

public class PlayerObjectInteractor : MonoBehaviour
{
    public static bool ShowInteractionUI = false;

    [HideInInspector] public InteractableObjectInfo currentObject;
    [SerializeField] InteractableObjectInfo[] objectInfo;
    private ObjectIdentification triggerObject;
    

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            InteractWithObject();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.GetComponent<ObjectType>()) {
            triggerObject = other.GetComponent<ObjectType>().objectType;
        }
    }

    private void OnTriggerExit(Collider other) {
        triggerObject = ObjectIdentification.None;
        currentObject = null;
        ShowInteractionUI = false;
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
            if (info.objectIdentification == triggerObject) {
                currentObject = info;
            }
            else {
                continue;
            }
        }
    }
}