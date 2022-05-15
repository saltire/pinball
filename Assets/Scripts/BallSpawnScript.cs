using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnScript : MonoBehaviour {
  public GameObject ball;

  public AudioClip drainSound;
  public AudioClip drainSound2;
  public AudioClip respawnSound;

  public float respawnDelay = 1f;

  bool drained;
  float respawnTime;

  AudioSource source;
  LightRunwayScript[] runways;

  void Start() {
    source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
    runways = FindObjectsOfType<LightRunwayScript>();

    Spawn();
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      Spawn();
    }

    if (drained && respawnTime <= Time.time) {
      source.PlayOneShot(respawnSound);
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

    drained = false;

    foreach (LightRunwayScript runway in runways) {
      runway.SetDeathMode(false);
    }
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Ball")) {
      source.PlayOneShot(Random.Range(0, 4) > 2 ? drainSound2 : drainSound);

      drained = true;
      respawnTime = Time.time + respawnDelay;

      foreach (LightRunwayScript runway in runways) {
        runway.SetDeathMode(true);
      }
    }
  }
}
