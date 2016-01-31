using UnityEngine;
using System.Collections;

public class PathNode : MonoBehaviour {

    public float WaitDuration = 0.0f;
    public bool IsOccupied { get { return isOccupied; } }
    public Vector2 Position { get { return position; } }

    private bool isOccupied = false;

    private Vector2 position;
    [HideInInspector] new public Transform transform;  // cache

    void Start () {
        transform = GetComponent<Transform>();
        position = (Vector2)transform.position;
    }
	
}
