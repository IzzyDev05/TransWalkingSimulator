﻿using UnityEngine;

public class CanHoldObject : MonoBehaviour
{
    [HideInInspector] public Transform objectToHold;

    private IKObjectGrabber objectGrabber;

    private void Start() {
        objectGrabber = FindObjectOfType<IKObjectGrabber>();
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "ObjectGrabber") {
            objectGrabber.objectInRange = true;
            objectToHold = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "ObjectGrabber") {
            objectGrabber.objectInRange = false;
            objectToHold = null;
        }
    }
}