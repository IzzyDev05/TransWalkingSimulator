using System.Collections;
using UnityEngine;

public class FadeScreenIn : MonoBehaviour
{
    private GameObject player;
    private PlayerMovement movementController;

    private void Start() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        player = GameObject.FindGameObjectWithTag("Player");
        movementController = player.GetComponent<PlayerMovement>();

        movementController.enabled = false;
    }

    public void BeginGame() {
        movementController.enabled = true;
        MouseLook.canMoveMouse = true;
    }
}