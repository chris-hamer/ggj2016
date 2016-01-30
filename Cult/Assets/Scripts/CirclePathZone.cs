using UnityEngine;
using System.Collections;

public class CirclePathZone : MonoBehaviour {
    /// <summary>
    /// Put this in an empty transform, and make that transform a child of the
    /// transform of a pillar. Then give the empty transform a big CircleCollider2D,
    /// centered on the pillar, and set the collider to trigger.
    /// </summary>

    public bool IsClockwise = true;
    public float RequiredAngularDistanceDegrees = 0.0f;
    public float ANGLE_DEGREES_TOLERANCE = 20.0f;

    [HideInInspector] new public CircleCollider2D collider2D; // cache

    private float angularDistanceTraveled = 0.0f;
    private Transform playerTransform;
    private Vector3 position3D;
    private Vector3 lastVector3D;
    private float clockwiseSign;
    private bool isTracking = false;

	// Use this for initialization
	void Start () {
        collider2D = GetComponent<CircleCollider2D>();
        position3D = GetComponent<Transform>().position;
        clockwiseSign = IsClockwise ? 1.0f : -1.0f;
        RequiredAngularDistanceDegrees = Mathf.Abs(RequiredAngularDistanceDegrees);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        // Compare the relative angular distance that the player has traveled
        if (isTracking) { 
            Vector3 newVector3D = playerTransform.position - transform.position;
            Vector3 cross = Vector3.Cross(newVector3D.normalized, lastVector3D.normalized);
            if (cross.z * clockwiseSign > 0.0f) {
                // going in the correct direction
                angularDistanceTraveled += 180 * Mathf.Abs(cross.z) / Mathf.PI;
            }
            else {
                // going in the incorrect direction => Unsafe!
                angularDistanceTraveled -= 180 * Mathf.Abs(cross.z) / Mathf.PI;
            }
            lastVector3D = newVector3D;
        }
	}

    // When the player enters the circular zone, start tracking the difference
    // between the player's position and the pillar's position
    void OnTriggerStay2D(Collider2D other) {
        if (other.transform==playerTransform) {
            isTracking = true;
            lastVector3D = other.transform.position - transform.position;
            playerTransform.GetComponent<PlayerControls>().circleSafe = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform == playerTransform)
        {
            if (Mathf.Abs(angularDistanceTraveled - RequiredAngularDistanceDegrees) > ANGLE_DEGREES_TOLERANCE) {
                // Player hasn't completed the circular route yet => Unsafe!
                Debug.Log("oh no " + angularDistanceTraveled + " " + RequiredAngularDistanceDegrees + " " + ANGLE_DEGREES_TOLERANCE);
                playerTransform.GetComponent<PlayerControls>().circleSafe = false;
            }
            else {
                Debug.Log("clear! " + angularDistanceTraveled + " " + RequiredAngularDistanceDegrees + " " + ANGLE_DEGREES_TOLERANCE);
                isTracking = false; // or whatever is meant to happen
            }
            
        }
    }
}
