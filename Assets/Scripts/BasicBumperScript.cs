using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBumperScript : MonoBehaviour {
  public float forceAmount = 80f;

  void OnTriggerEnter(Collider other) {
    other.attachedRigidbody.AddForce(transform.rotation * Vector3.forward * forceAmount);
  }
}
