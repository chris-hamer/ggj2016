using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    new private Rigidbody2D rigidbody;

    public const float SPEED = 0.07f;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Move using keyboard input
        Vector2 moveVec = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            moveVec += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            moveVec += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveVec += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            moveVec += Vector2.right;
        rigidbody.MovePosition(rigidbody.position + moveVec * SPEED);
    }
}
