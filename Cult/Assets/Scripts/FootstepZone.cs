using UnityEngine;
using System.Collections;

public class FootstepZone : MonoBehaviour {

    public Vector2 direction;
    public PlayerControls playerControls;
    public bool corner;
	
	void Start ()
    {
        playerControls = FindObjectOfType<PlayerControls>();
        direction = direction.normalized;
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // Player is safe if they're moving in any direction at a corner or they're actively following the path
            playerControls.safe = (corner ? playerControls.velocity.magnitude > 0 : playerControls.velocity.normalized == direction);
        }
    }
}
