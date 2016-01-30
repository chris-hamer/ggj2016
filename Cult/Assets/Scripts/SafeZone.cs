using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

    public PlayerControls controls;
    public bool RequireHat;

    void Start()
    {
        controls = FindObjectOfType<PlayerControls>();
    }

	void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            controls.safe = !RequireHat || controls.hasHat && RequireHat;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            controls.safe = false;
    }
}
