using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public static ThemeSong instance;

    private AudioSource source;
    private AudioLowPassFilter lowPassFilter;
    private bool doesPlayerExist = true;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        source = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        source.Play();
    }

    private void Update() {
        if (GameObject.Find("Player") != null) {
            doesPlayerExist = true;
        }
        else {
            doesPlayerExist = false;
        }

        if (doesPlayerExist) {
            lowPassFilter.cutoffFrequency = 22000f;     
        }
        else {
            lowPassFilter.cutoffFrequency = 1500f;
        }
    }
}
