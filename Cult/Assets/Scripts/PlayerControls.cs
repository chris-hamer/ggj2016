using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    new private Rigidbody2D rigidbody;
    private CharacterSprites sprites;

    public const float SPEED = 0.035f;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponent<CharacterSprites>();
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

        if (sprites != null)
            sprites.SetDirection(moveVec);

        if (Input.GetKey(KeyCode.LeftShift))
            moveVec *= 2f;

        rigidbody.MovePosition(rigidbody.position + moveVec * SPEED);
    }
}
