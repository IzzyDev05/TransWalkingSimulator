using UnityEngine;

public class SwitchInteractor : MonoBehaviour
{
    [SerializeField] GameObject toggleCanvas;
    
    [Header("Raycast variables")]
    [SerializeField] Transform rayPos;
    [SerializeField] LayerMask lightingLayer;
    [SerializeField] float rayDistance;

    private bool isCanvasOn = false;

    private void Start() {
        toggleCanvas.SetActive(false);
    }

    private void Update() {
        Raycast();
        HandleUI();
    }

    private void Raycast() {
        RaycastHit hit;

        if (Physics.Raycast(rayPos.position, Camera.main.transform.forward, out hit, rayDistance, lightingLayer)) {
            //Debug.DrawRay(rayPos.position, Camera.main.transform.forward * hit.distance, Color.yellow);

            GetLights(hit);
            isCanvasOn = true;
        }
        else {
            isCanvasOn = false;
        }
    }

    private void GetLights(RaycastHit hit) {
        Light[] lights = hit.collider.GetComponentsInChildren<Light>();

        foreach (Light light in lights) {
            if (Input.GetKeyDown(KeyCode.L)) {
                if (light.enabled) {
                    light.enabled = false;
                }
                else {
                    light.enabled = true;
                }
            }
        }
    }

    private void HandleUI() {
        if (isCanvasOn) {
            toggleCanvas.SetActive(true);
        }
        else {
            toggleCanvas.SetActive(false);
        }
    }
}