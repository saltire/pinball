using UnityEngine;

public class LightScript : MonoBehaviour {
  public Color color = Color.white;
  public float intensity = 2f;

  void Awake() {
    Renderer render = GetComponent<Renderer>();
    MaterialPropertyBlock block = new MaterialPropertyBlock();
    render.GetPropertyBlock(block);
    block.SetColor("_EmissionColor", color * intensity);
    render.SetPropertyBlock(block);
  }
}
