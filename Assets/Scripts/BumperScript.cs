using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour {
  public float upwardForce = 10f;
  public float downwardForce = 10f;

  public float hitIntensity = 2f;
  public float lightFadeDuration = 1f;

  public Rigidbody cone;
  public Light bumperLight;

  public AudioClip sound1;
  public AudioClip sound2;
  AudioSource source;

  void Start() {
    source = FindObjectOfType<AudioSource>();
  }

  void Update() {
    if (bumperLight.intensity > 1) {
      bumperLight.intensity = Mathf.Max(1,
        bumperLight.intensity - (hitIntensity - 1) * Time.deltaTime / lightFadeDuration);
    }
  }

  // Something weird with the cone mesh, its Y-axis is inverted.
  void FixedUpdate() {
    cone.AddRelativeForce(Vector3.down * upwardForce);
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Ball")) {
      cone.AddRelativeForce(Vector3.up * downwardForce, ForceMode.Impulse);
      bumperLight.intensity = hitIntensity;

      source.PlayOneShot(Random.Range(0, 2) > 0 ? sound1 : sound2);
    }
  }
}
