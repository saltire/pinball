using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side {
  Left,
  Right,
}

public class FlipperScript : MonoBehaviour {
  public Side side;

  HingeJoint hinge;

  void Start() {
    hinge = GetComponent<HingeJoint>();
  }

  void Update() {
    string key = side == Side.Left ? "left shift" : "right shift";

    if (Input.GetKeyDown(key)) {
      hinge.useMotor = true;
    }
    else if (Input.GetKeyUp(key)) {
      hinge.useMotor = false;
    }
  }
}
