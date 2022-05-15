using UnityEngine;

public class LightScript : MonoBehaviour {
  public Color color = Color.white;
  public float intensity = 2f;

  Renderer render;
  Light pointLight;

  void Awake() {
    render = GetComponent<Renderer>();
    pointLight = GetComponentInChildren<Light>();

    SetColor(color, intensity);
  }

  public void SetColor(Color newColor, float newIntensity) {
    MaterialPropertyBlock block = new MaterialPropertyBlock();
    render.GetPropertyBlock(block);
    block.SetColor("_EmissionColor", newColor * newIntensity);
    render.SetPropertyBlock(block);

    pointLight.color = newColor;
    pointLight.intensity = newIntensity;
  }
}
