using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
  Vector3 initialPosition;

  void Spawn() {
    transform.position = new Vector3(Random.Range(-.25f, .25f),
      initialPosition.y, initialPosition.z);
  }

  void Start() {
    initialPosition = transform.position;

    Spawn();
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      Spawn();
    }
  }
}
