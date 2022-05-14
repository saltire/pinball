using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpScript : MonoBehaviour
{
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public bool hasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, 0.015f, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTriggered == true) {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.localPosition.x, -0.0164f, 0.0107f), ref velocity, smoothTime);
        }
        else if (hasTriggered == false) {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, 0.014f, 0.0107f), ref velocity, smoothTime);
        }
    }

    public void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.tag == "Ball") {
            hasTriggered = true;
        }
    }    
}
