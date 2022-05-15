using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBumperScript : MonoBehaviour {
  public float forceAmount = 80f;

  public Light bumperLight;
  public float hitIntensity = 2f;
  public float lightFadeDuration = 1f;

  float initialIntensity = 1.5f;

  public AudioClip sound;

  AudioSource source;

  void Start() {
    initialIntensity = bumperLight.intensity;

    source = FindObjectOfType<AudioSource>();
  }

  void Update() {
    if (bumperLight.intensity > initialIntensity) {
      bumperLight.intensity = Mathf.Max(initialIntensity,
        bumperLight.intensity - (hitIntensity - initialIntensity) * Time.deltaTime / lightFadeDuration);
    }
  }

  void OnTriggerEnter(Collider other) {
    other.attachedRigidbody.AddForce(transform.rotation * Vector3.forward * forceAmount);
    bumperLight.intensity = hitIntensity;

    source.PlayOneShot(sound);
  }
}
