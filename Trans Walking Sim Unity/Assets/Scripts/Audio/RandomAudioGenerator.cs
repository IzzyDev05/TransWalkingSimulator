using UnityEngine;

public class RandomAudioGenerator : MonoBehaviour
{
    [SerializeField] string[] grassSoundNames;
    [SerializeField] string[] woodSoundNames;
    [SerializeField] string[] gravelSoundNames;

    private AudioManager audioManager;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public string ChooseRandomGrassSound() {
        int soundIndex = Random.Range(0, grassSoundNames.Length);
        string selectedSound = grassSoundNames[soundIndex];

        return selectedSound;
    }

    public string ChooseRandomWoodSound() {
        int soundIndex = Random.Range(0, woodSoundNames.Length);
        string selectedSound = woodSoundNames[soundIndex];

        return selectedSound;
    }

    public string ChooseRandomGravelSound() {
        int soundIndex = Random.Range(0, gravelSoundNames.Length);
        string selectedSound = gravelSoundNames[soundIndex];

        return selectedSound;
    }
}
