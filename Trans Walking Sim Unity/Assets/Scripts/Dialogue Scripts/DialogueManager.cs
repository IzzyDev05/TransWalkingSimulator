using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] NPC npc;
    [SerializeField] GameObject player;
    [SerializeField] GameObject dialogueUI;

    [SerializeField] TMP_Text npcName;
    [SerializeField] TMP_Text npcDialogueBox;
    [SerializeField] TMP_Text playerResponse;

    private float distance;
    private float currentResponseTracker = 0;
    private bool isTalking = false;

    private void Start() {
        dialogueUI.SetActive(false);
    }

    private void Update() {
        distance = Vector3.Distance(player.transform.position, this.transform.position);

        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            currentResponseTracker++;
            if (currentResponseTracker >= npc.playerDialouge.Length - 1) {
                currentResponseTracker = npc.playerDialouge.Length - 1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            currentResponseTracker--;
            if (currentResponseTracker < 0) {
                currentResponseTracker = 0;
            }
        }

        if (distance <= 2.5f) {
            if (Input.GetKeyDown(KeyCode.E) && !isTalking) {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking) {
                EndConversation();
            }
        }

        HandleResponses();
    }

    private void StartConversation() {
        isTalking = true;
        currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.nameOfNPC;
        npcDialogueBox.text = npc.dialouge[0];
    }

    private void EndConversation() {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    private void HandleResponses() {
        if (currentResponseTracker == 0 && npc.playerDialouge.Length >= 0) {
            playerResponse.text = npc.playerDialouge[0];
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueBox.text = npc.dialouge[1];
            }
        }
        else if (currentResponseTracker == 1 && npc.playerDialouge.Length >= 1) {
            playerResponse.text = npc.playerDialouge[1];
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueBox.text = npc.dialouge[2];
            }
        }
        else if (currentResponseTracker == 2 && npc.playerDialouge.Length >= 2) {
            playerResponse.text = npc.playerDialouge[2];
            if (Input.GetKeyDown(KeyCode.Return)) {
                npcDialogueBox.text = npc.dialouge[3];
            }
        }
    }
}