using UnityEngine;

public class BallScript : MonoBehaviour {
  Vector3 initialPosition;

  void Start() {
    initialPosition = transform.position;
  }

  void Update() {
    if (Input.GetKeyUp("escape")) {
      transform.position = initialPosition;
    }
  }
}
