using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform playerBody;

    [Header("Camera movement speeds")]
    [SerializeField] float horizontalSpeed = 100;
    [SerializeField] float verticalSpeed = 100;

    [Header("Vertical rotation clamp values")]
    [Tooltip("Max downwards rotation (Enter as negative)")] [SerializeField] float xClampMin = -90f;
    [Tooltip("Max upwards rotation (Enter as positive)")] [SerializeField] float xClampMax = 90f;

    [Header("Horizontal rotation clamp values")]
    [Tooltip("Max left rotation")]  [SerializeField] float yClampMin = -90f;
    [Tooltip("Max right rotation")]  [SerializeField] float yClampMax = 90f;
    [Tooltip("Rotation smoothening factor")] [SerializeField] float dampenFactor = 0.1f;
     
    private float yaw = 0;
    private float pitch = 0;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate() {
        yaw += horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch += verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, xClampMin, xClampMax);

        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
        playerBody.eulerAngles = new Vector3(0, yaw, 0);
    }
}