using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StandUpSetScript : MonoBehaviour {
  public float resetDelay = 1f;

  bool reset;
  float resetTime;

  public AudioClip[] resetSounds;

  StandUpScript[] standups;
  Dictionary<StandUpScript, bool> hits = new Dictionary<StandUpScript, bool>();

  AudioSource source;

  void Start() {
    source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();

    standups = GetComponentsInChildren<StandUpScript>();
    foreach (StandUpScript standup in standups) {
      hits[standup] = false;
    }
  }

  void Update() {
    if (reset && resetTime <= Time.time) {
      reset = false;

      foreach (StandUpScript standup in standups) {
        hits[standup] = false;
        standup.Reset();
      }

      source.PlayOneShot(resetSounds[Random.Range(0, resetSounds.Length)]);
    }
  }

  public void OnHit(StandUpScript standup) {
    hits[standup] = true;

    if (hits.Values.All(hit => hit)) {
      reset = true;
      resetTime = Time.time + resetDelay;
    }
  }
}
