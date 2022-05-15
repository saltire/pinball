using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpScript : MonoBehaviour {
    public float moveSpeed = 0.001f;
    public bool hasTriggered = false;

    public AudioClip hitSound;

    Vector3 upPosition;
    Vector3 downPosition;

    StandUpSetScript set;
    AudioSource source;

    void Start() {
        upPosition = transform.position;
        downPosition = transform.position + Vector3.down * transform.localScale.y;

        set = GetComponentInParent<StandUpSetScript>();
        source = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
    }

    void Update() {
        if (hasTriggered && transform.position != downPosition) {
            transform.position += Vector3.down
                * Mathf.Min(moveSpeed, Vector3.Distance(transform.position, downPosition));
        }
        else if (!hasTriggered && transform.position != upPosition) {
            transform.position += Vector3.up
                * Mathf.Min(moveSpeed, Vector3.Distance(transform.position, upPosition));
        }
    }

    public void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Ball") {
            hasTriggered = true;

            set.OnHit(this);

            source.PlayOneShot(hitSound);
        }
    }

    public void Reset() {
        hasTriggered = false;
    }
}
