using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {
    public AudioClip intro;
    public AudioClip main;

    AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();

        source.PlayOneShot(intro);

        source.clip = main;
        source.PlayDelayed(intro.length);
    }

    void Update() {
        if (Input.GetKeyUp("m")) {
            source.mute = !source.mute;
        }
    }
}
