using UnityEngine;
using System.Collections;

public class FailPathDie : MonoBehaviour {

    public float deathMaxTime = 0.5f;

    private float dyingTimer = -1.0f;
    [HideInInspector] new public Transform transform;
    private SpriteRenderer spriteRenderer;

    void Start () {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void KillMe() {
        dyingTimer = deathMaxTime;
    }
	
	void Update () {
	    if (dyingTimer >= 0.0f) {
            float pctLeft = Mathf.Max(0.0f, dyingTimer/ deathMaxTime);
            spriteRenderer.color = new Color(1.0f, pctLeft, pctLeft, pctLeft);
            dyingTimer -= Time.deltaTime;
            if (dyingTimer <= 0.0f) {
                GameObject.Destroy(this.gameObject);
            }
        }
	}
}
