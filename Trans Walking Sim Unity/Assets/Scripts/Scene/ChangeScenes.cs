using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] int newScene;
    [SerializeField] int realLifeScene;

    public void ChangeScene() {
        SceneManager.LoadScene(newScene);
    }

    public void DiedInDream() {
        SceneManager.LoadScene(realLifeScene);
    }
}
