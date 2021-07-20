﻿using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //[SerializeField] Transform playerBody;

    [HideInInspector] public float yaw = 0;
    [HideInInspector] public float pitch = 0;

    [Header("Camera movement speeds")]
    [SerializeField] float horizontalSpeed = 100;
    [SerializeField] float verticalSpeed = 100;

    [Header("Vertical rotation clamp values")]
    [Tooltip("Max downwards rotation (Enter as negative)")] [SerializeField] float xClampMin = -90f;
    [Tooltip("Max upwards rotation (Enter as positive)")] [SerializeField] float xClampMax = 90f;

    private void LateUpdate() {
        yaw += horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        pitch += verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;

        pitch = Mathf.Clamp(pitch, xClampMin, xClampMax);

        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
    }
}