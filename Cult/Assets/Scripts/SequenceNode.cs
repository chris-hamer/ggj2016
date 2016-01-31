using UnityEngine;
using System.Collections;

public class SequenceNode : MonoBehaviour {

    public SpriteRenderer torchSpriteRenderer = null;

    private SequenceObject owner = null;
    [HideInInspector] new public CircleCollider2D collider;
    private Transform playerTransform;

	void Awake () {
        collider = GetComponent<CircleCollider2D>();
    }

	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (torchSpriteRenderer != null) {
            torchSpriteRenderer.enabled = false;
        }
	}

    public void SetOwner(SequenceObject sequenceObject) {
        owner = sequenceObject;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform == playerTransform) {
            owner.ActivateTrigger(this);
            if (torchSpriteRenderer != null) {
                torchSpriteRenderer.enabled = true;
            }
        }
    }


}
