using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatScript : MonoBehaviour {
  void OnTriggerEnter(Collider other) {
    if (other.attachedRigidbody != null) {
      Vector3 dir = Vector3.Cross(other.attachedRigidbody.velocity, Vector3.down);

      Debug.DrawLine(transform.position, transform.position + dir,
        Color.yellow, 10f);
      GetComponent<Rigidbody>().AddTorque(dir * 100f, ForceMode.Impulse);
    }
  }

  void FixedUpdate() {
    Vector3 dir = Vector3.Cross(transform.rotation * Vector3.down, Vector3.down);
    GetComponent<Rigidbody>().AddTorque(dir * 100f);
  }
}
