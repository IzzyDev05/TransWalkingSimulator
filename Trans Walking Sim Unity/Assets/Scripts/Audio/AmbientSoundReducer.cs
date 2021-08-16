using UnityEngine;

public class AmbientSoundReducer : MonoBehaviour
{
    private GameObject[] ambientAudioSources;

    private void Start() {
        ambientAudioSources = GameObject.FindGameObjectsWithTag("Ambient");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            foreach (GameObject source in ambientAudioSources) {
                var currentVolume = source.GetComponent<AudioSource>().volume;
                var newVolume = currentVolume / 2;

                source.GetComponent<AudioSource>().volume = newVolume;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            foreach (GameObject source in ambientAudioSources) {
                var currentVolume = source.GetComponent<AudioSource>().volume;
                var newVolume = currentVolume * 2;

                source.GetComponent<AudioSource>().volume = newVolume;
            }
        }
    }
}