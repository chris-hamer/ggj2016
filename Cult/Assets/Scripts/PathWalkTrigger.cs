using UnityEngine;
using System.Collections;

public class PathWalkTrigger : MonoBehaviour {

    [HideInInspector] new public Transform transform;
    [HideInInspector] new public Collider2D collider;

    public float DelayCollisionDetection = 0.0f;

    private PathWalk pathWalk;
    private Transform playerTransform;

    private bool isTriggered = false;

	void Awake() {
        transform = GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
        pathWalk = GetComponent<PathWalk>();
    }

    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (DelayCollisionDetection > 0.0f) {
            collider.enabled = false;
        }
    }

    void Update() {
        if (DelayCollisionDetection > 0.0f) {
            DelayCollisionDetection -= Time.deltaTime;
            if (DelayCollisionDetection <= 0.0f) {
                collider.enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!isTriggered) {
            if (other.transform == playerTransform) {
                isTriggered = true;
                pathWalk.BeginWalk();
            }
        }
    }

    /*
    void OnTriggerExit2D(Collider2D other) {
        if (isTriggered) {
            if (other.transform == playerTransform) {
                isTriggered = false;
                Debug.Log("YOU DONE GOOFED");
                pathWalk.StopWalk();
            }
        }
    }*/

}
