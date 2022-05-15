using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatScript : MonoBehaviour {
  public AudioClip sound;

  AudioSource source;

  void Start() {
    source = FindObjectOfType<AudioSource>();
  }

  void OnTriggerEnter(Collider other) {
    if (other.attachedRigidbody != null) {
      Vector3 dir = Vector3.Cross(other.attachedRigidbody.velocity, Vector3.down);

      GetComponent<Rigidbody>().AddTorque(dir * 100f, ForceMode.Impulse);

      source.PlayOneShot(sound);
    }
  }

  void FixedUpdate() {
    Vector3 dir = Vector3.Cross(transform.rotation * Vector3.down, Vector3.down);
    GetComponent<Rigidbody>().AddTorque(dir * 100f);
  }
}
