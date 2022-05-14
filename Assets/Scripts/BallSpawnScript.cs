using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnScript : MonoBehaviour {
  public GameObject ball;

  void Start() {
    Spawn();
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      Spawn();
    }
  }

  void Spawn() {
    foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball")) {
      GameObject.Destroy(ball);
    }

    foreach (GameObject spawnPoint in GameObject.FindGameObjectsWithTag("SpawnPoint")) {
      Instantiate(ball, spawnPoint.transform.position, Quaternion.identity);
    }
  }
}
