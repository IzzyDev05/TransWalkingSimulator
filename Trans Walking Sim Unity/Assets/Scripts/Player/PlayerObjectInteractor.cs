using UnityEngine;

public class PlayerObjectInteractor : MonoBehaviour
{
    [SerializeField] InteractableObjectInfo[] objectInfo;

    private ObjectIdentification triggerObject;
    private InteractableObjectInfo currentObject;

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
    }

    private void InteractWithObject() {
        ObjectLocator();

        if (currentObject) {
            print("The name of the object: " + currentObject.objectName);
            print(currentObject.backStory);
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