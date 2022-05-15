using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightRunwayScript : MonoBehaviour {
  public float lightDuration = .1f;
  public float intensity = 2f;

  LightScript[] lights;

  void Start() {
    lights = GetComponentsInChildren<LightScript>();

    MaterialPropertyBlock block = new MaterialPropertyBlock();

    foreach ((LightScript light, int i) in lights.Select((light, i) => (light, i))) {
      light.SetColor(Color.black, 1);

      light.color = Color.HSVToRGB((float)i / lights.Length, 1, 1);
    }

    StartCoroutine(Runway());
  }

  IEnumerator Runway() {
    MaterialPropertyBlock block = new MaterialPropertyBlock();

    foreach (LightScript light in lights) {
      light.SetColor(light.color, intensity);

      yield return new WaitForSeconds(lightDuration);

      light.SetColor(Color.black, 1);
    }

    StartCoroutine(Runway());
  }
}
