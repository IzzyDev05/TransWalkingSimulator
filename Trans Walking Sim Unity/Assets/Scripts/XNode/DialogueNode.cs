using UnityEngine;

public class DialogueNode : BaseNode
{
    [Input] public int entry;
    [Output] public int exit0;
    [Output] public int exit1;
    [Output] public int exit2;
    [Output] public int exit3;

    public string speakerName;
    public string dialogueLine;

    public override string GetString() {
        return "DialogueNode/" + speakerName + "/" + dialogueLine;
    }
}