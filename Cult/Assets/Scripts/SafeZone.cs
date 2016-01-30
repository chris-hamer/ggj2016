using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

    public PlayerControls controls;

    void Start()
    {
        controls = FindObjectOfType<PlayerControls>();
    }

	void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            controls.safe = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            controls.safe = false;
    }
}
