using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightRunwayScript : MonoBehaviour {
  public float lightDuration = .1f;
  public float intensity = 2f;

  bool deathMode = false;

  LightScript[] lights;

  void Awake() {
    lights = GetComponentsInChildren<LightScript>();
  }

  void Start() {
    MaterialPropertyBlock block = new MaterialPropertyBlock();

    foreach ((LightScript light, int i) in lights.Select((light, i) => (light, i))) {
      light.SetColor(Color.black, 1);

      light.color = Color.HSVToRGB((float)i / lights.Length, 1, 1);
    }

    StartCoroutine(Runway());
  }

  public void SetDeathMode(bool enabled) {
    deathMode = enabled;

    foreach (LightScript light in lights) {
      if (deathMode) {
        light.SetColor(Color.red, 2);
      }
      else {
        light.SetColor(Color.black, 1);
      }
    }
  }

  IEnumerator Runway() {
    MaterialPropertyBlock block = new MaterialPropertyBlock();

    foreach (LightScript light in lights) {
      if (!deathMode) {
        light.SetColor(light.color, intensity);
      }

      yield return new WaitForSeconds(lightDuration);

      if (!deathMode) {
        light.SetColor(Color.black, 1);
      }
    }

    StartCoroutine(Runway());
  }
}
