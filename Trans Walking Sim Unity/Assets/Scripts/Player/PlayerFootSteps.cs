using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    private AudioManager audioManager;
    private RandomAudioGenerator randomAudioGenerator;

    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
        randomAudioGenerator = FindObjectOfType<RandomAudioGenerator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Gravel") {
            string gravelSound = randomAudioGenerator.ChooseRandomGravelSound();
            audioManager.Play(gravelSound);
        }

        if (other.tag == "Grass") {
            string grassSound = randomAudioGenerator.ChooseRandomGrassSound();
            audioManager.Play(grassSound);
        }

        if (other.tag == "Wood") {
            string woodSound = randomAudioGenerator.ChooseRandomWoodSound();
            audioManager.Play(woodSound);
        }
    }

    private void OnTriggerExit(Collider other) {
        audioManager.Stop();
    }
}
