using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    public float loopTime = 1f;
    public float moveAmount = 1.1f;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initialPosition + Vector3.right * moveAmount * (Time.time % loopTime);


        if (Input.anyKey) {
            SceneManager.LoadScene("Pinball");
        }
    }
}
