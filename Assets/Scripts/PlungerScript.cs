using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour {
  public float pushForce = 200f;
  public float pullForce = 200.1f;

  Rigidbody rb;

  public AudioClip releaseSound;

  AudioSource source;

  void Start() {
    rb = GetComponent<Rigidbody>();

    source = FindObjectOfType<AudioSource>();
  }

  void FixedUpdate() {
    rb.AddRelativeForce(Vector3.up * pushForce);

    if (Input.GetKey("down")) {
      rb.AddRelativeForce(Vector3.down * pullForce);
    }
  }

  void Update() {
    if (Input.GetKeyUp("down")) {
      source.PlayOneShot(releaseSound);
    }
  }
}
