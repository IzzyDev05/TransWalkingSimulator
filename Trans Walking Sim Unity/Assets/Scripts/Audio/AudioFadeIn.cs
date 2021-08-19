using System.Collections;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    [SerializeField] float fadeTime = 0.2f;
    private AudioSource[] audioSources;

    private void Start() {
        audioSources = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource source in audioSources) {
            IEnumerator fadeSound = AudioManager.FadeIn(source, fadeTime);
            StartCoroutine(fadeSound);
        }
    }
}
