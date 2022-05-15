using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {
  public AudioClip start1;
  public AudioClip start2;

  public float start2Delay = .5f;
  bool played2 = false;

  AudioSource source;

  void Start() {
    source = GetComponent<AudioSource>();

    source.PlayOneShot(start1);
  }

  void Update() {
    if (!played2 && Time.time >= start2Delay) {
      source.PlayOneShot(start2);
      played2 = true;
    }
  }
}
