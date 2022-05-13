using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour {
  public float upwardForce = 10f;
  public float downwardForce = 10f;

  public Rigidbody cone;

  // Something weird with the cylinder mesh, its Y-axis is inverted.
  void FixedUpdate() {
    cone.AddRelativeForce(Vector3.down * upwardForce);
  }

  void OnTriggerEnter(Collider other) {
    cone.AddRelativeForce(Vector3.up * downwardForce, ForceMode.Impulse);
  }
}
