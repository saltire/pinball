using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side {
  Left,
  Right,
}

public class FlipperScript : MonoBehaviour {
  public Side side;

  public AudioClip soundOn;
  public AudioClip soundOff;

  HingeJoint hinge;
  AudioSource source;

  void Start() {
    source = FindObjectOfType<AudioSource>();
    hinge = GetComponent<HingeJoint>();
  }

  void Update() {
    string key = side == Side.Left ? "left shift" : "right shift";

    if (Input.GetKeyDown(key)) {
      hinge.useMotor = true;
      source.PlayOneShot(soundOn);
    }
    else if (Input.GetKeyUp(key)) {
      hinge.useMotor = false;
      source.PlayOneShot(soundOff);
    }
  }
}
