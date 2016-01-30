using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {

    public float WaitDuration { get { return waitDuration; } }
    public bool IsOccupied { get { return isOccupied; } }
    public Vector2 Position { get { return position; } }

    private bool isOccupied = false;
    private float waitDuration = 0.0f;

    private Vector2 position;
    new private Transform transform;

	void Start () {
        transform = GetComponent<Transform>();
        position = (Vector2)transform.position;
    }
	
}
