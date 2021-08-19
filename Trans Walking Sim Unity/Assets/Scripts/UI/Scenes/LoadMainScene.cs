using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

	SceneManager.LoadScene(1);
    }
}
