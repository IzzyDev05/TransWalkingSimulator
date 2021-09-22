using UnityEngine;

[CreateAssetMenu(fileName = "Interactable Object Info", menuName = "Scriptable Objects/Interactable Object Info")]
public class InteractableObjectInfo : ScriptableObject
{
    public string objectName;
    [TextArea(15,20)] public string backStory;
    public ObjectIdentification objectIdentification;
}

public enum ObjectIdentification
{
    None,
    TransPyramid,
    BedsidePlate,
    DoorLock
}