using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using XNode;

public class NodeParser : MonoBehaviour
{
    public DialogueGraph graph;

    [SerializeField] string playerName;
    [SerializeField] string npcName;
    [SerializeField] TMP_Text speaker;
    [SerializeField] TMP_Text dialogue;

    private List<GameObject> playerOptionButtons = new List<GameObject>();
    private List<GameObject> playerOptionText = new List<GameObject>();
    private Coroutine _parser;

    private void Start() {
        foreach (BaseNode b in graph.nodes) {
            if (b.GetString() == "Start") {
                graph.current = b;
                break;
            }
        }

        _parser = StartCoroutine(ParseNode());
    }

    private IEnumerator ParseNode() {
        BaseNode b = graph.current;
        string data = b.GetString();
        string[] dataParts = data.Split('/');

        if (dataParts[0] == "Start") {
            NextNode("exit");
        }

        if (dataParts[0] == "DialogueNode") {
            speaker.text = npcName;

            if (dataParts[1] == npcName) {
                dialogue.text = dataParts[2];
            }
            else {
                CreatePlayerDialogue(dataParts);
            }

            yield return new WaitForSeconds(0.0001f);
        }
    }

    public void NextNode(string fieldName) {
        if (_parser != null) {
            StopCoroutine(_parser);
            _parser = null;
        }

        foreach (NodePort p in graph.current.Ports) {
            if (p.fieldName == fieldName) {
                graph.current = p.Connection.node as BaseNode;
                break;
            }
        }

        _parser = StartCoroutine(ParseNode());
    }

    public void ButtonPress(int index) {
        NextNode("exit" + index);
    }

    private void CreatePlayerDialogue(string[] dataParts) {
        playerOptionButtons.AddRange(GameObject.FindGameObjectsWithTag("PlayerOption"));
        playerOptionText.AddRange(GameObject.FindGameObjectsWithTag("PlayerOptionText"));

        foreach (var item in playerOptionText) {
            TMP_Text currentText = item.GetComponent<TMP_Text>();

            currentText.text = dataParts[2];
        }
    }
}