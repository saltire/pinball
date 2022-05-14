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

    foreach ((LightScript light, int i) in lights.Select((light, i) => (light, i))) {
      light.color = Color.HSVToRGB((float)i / lights.Length, 1, 1);
    }

    StartCoroutine(Runway());
  }

  IEnumerator Runway() {
    MaterialPropertyBlock block = new MaterialPropertyBlock();

    foreach (LightScript light in lights) {
      Renderer render = light.GetComponent<Renderer>();
      render.GetPropertyBlock(block);

      block.SetColor("_EmissionColor", light.color * intensity);
      render.SetPropertyBlock(block);

      yield return new WaitForSeconds(lightDuration);

      block.SetColor("_EmissionColor", Color.black);
      render.SetPropertyBlock(block);
    }

    StartCoroutine(Runway());
  }
}
