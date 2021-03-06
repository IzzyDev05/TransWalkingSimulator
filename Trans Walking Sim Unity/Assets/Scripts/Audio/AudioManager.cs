using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop() {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        
        foreach (AudioSource source in audioSources) {
            source.Stop();
        }
    }

    public static IEnumerator FadeIn(AudioSource source, float fadeTime) {
        float finalVolume = source.volume;
        source.volume = 0;

        while (source.volume < finalVolume) {
            source.volume += finalVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        source.volume = finalVolume;
    }
}