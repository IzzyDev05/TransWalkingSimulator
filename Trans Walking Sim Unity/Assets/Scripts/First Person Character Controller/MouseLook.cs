using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100;
    [SerializeField] Transform playerBody;

    private float xRot = 0;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}