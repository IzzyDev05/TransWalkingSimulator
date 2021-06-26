using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default file name", menuName = "Create NPC File")]
public class NPC : ScriptableObject
{
    public string nameOfNPC;
    [TextArea(3, 15)] public string[] dialouge;
    [Tooltip("Player dialouge should always be 1 less than NPC dialouge as NPC will have a greeting message")] [TextArea(3, 15)] public string[] playerDialouge;
}