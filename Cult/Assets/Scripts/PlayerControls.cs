using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    new private Rigidbody2D rigidbody;
    private CharacterSprites sprites;

    public const float SPEED = 0.035f;
    public const float DETECTION_RATE = 1.5f;
    public const float DETECTION_COOLDOWN = 0.4f;

    public bool safe;
    public float detection;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponent<CharacterSprites>();
        safe = true;
        detection = 0f;
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

        // Face sprite the right way
        if (sprites != null)
            sprites.SetDirection(moveVec);

        // Sprint button because walking is slow
        if (Input.GetKey(KeyCode.LeftShift))
            moveVec *= 2f;

        // Yeah
        rigidbody.MovePosition(rigidbody.position + moveVec * SPEED);

        if (!safe)
            detection += DETECTION_RATE * Time.deltaTime;
        else
            detection -= DETECTION_COOLDOWN * Time.deltaTime;

        if (detection < 0f)
            detection = 0f;
        else if (detection >= 1f)
        {
            detection = 1f;
            Debug.Log("You suck");
        }
    }
}
