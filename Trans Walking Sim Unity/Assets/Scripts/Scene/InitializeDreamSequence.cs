using UnityEngine;

public class InitializeDreamSequence : MonoBehaviour
{
    [Header("Raycast variables")]
    [SerializeField] Transform rayPos;
    [SerializeField] LayerMask bedLayer;
    [SerializeField] float rayDistance;

    [Header("Game objects")]
    [SerializeField] GameObject dreamUI;
    [SerializeField] GameObject sceneChanger;

    private void Start() {
        dreamUI.SetActive(false);
        sceneChanger.SetActive(false);
    }

    private void Update() {
        Raycast();
    }

    private void Raycast() {
        RaycastHit hit;

        if (Physics.Raycast(rayPos.position, Camera.main.transform.forward, out hit, rayDistance, bedLayer)) {
            //Debug.DrawRay(rayPos.position, Camera.main.transform.forward * hit.distance, Color.yellow);
            dreamUI.SetActive(true);
            GetInput();
        }
        else {
            dreamUI.SetActive(false);
        }
    }

    private void GetInput() {
        if (Input.GetButtonDown("ActionKey")) {
            dreamUI.SetActive(false);
            sceneChanger.SetActive(true);
        }
    }
}
