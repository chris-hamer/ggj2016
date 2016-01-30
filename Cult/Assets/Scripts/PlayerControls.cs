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

    public static GameObject player;
    public Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponent<CharacterSprites>();
        safe = true;
        detection = 0f;

        if (player == null)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            player = this.gameObject;
        }
        else if (player != this.gameObject)
        {
            Destroy(this);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Move using keyboard input
        velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            velocity += Vector2.up * SPEED;
        if (Input.GetKey(KeyCode.DownArrow))
            velocity += Vector2.down * SPEED;
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity += Vector2.left * SPEED;
        if (Input.GetKey(KeyCode.RightArrow))
            velocity += Vector2.right * SPEED;

        // Face sprite the right way
        if (sprites != null)
            sprites.SetDirection(velocity);

        // Sprint button because walking is slow
        if (Input.GetKey(KeyCode.LeftShift))
            velocity *= 2f;

        // Yeah
        rigidbody.MovePosition(rigidbody.position + velocity);

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
