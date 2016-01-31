using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    new private Rigidbody2D rigidbody;
    private CharacterSprites sprites;

    public const float SPEED = 0.035f;
    public const float DETECTION_RATE = 1.5f;
    public const float DETECTION_COOLDOWN = 0.4f;

    public bool safe;
    public bool circleSafe;
    public float detection;
    public bool hasHat;

    public static GameObject player;
    public Vector2 velocity;

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponent<CharacterSprites>();
    }

    // Use this for initialization
    void Start()
    {
       safe = true;
        circleSafe = false;
        detection = 0f;

        if (player == null)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            player = this.gameObject;
        }
        else if (player != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Transform g in GameObject.FindObjectsOfType<Transform>())
            {
                if (g.gameObject != gameObject)
                    GameObject.Destroy(g.gameObject);
            }
            SceneManager.LoadScene("tutorial2", LoadSceneMode.Additive);
        }

        // Move using keyboard input
        velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            velocity += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            velocity += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            velocity += Vector2.right;
        velocity.Normalize();

        // Face sprite the right way
        if (sprites != null)
            sprites.SetSpriteDirection(velocity);

        // Sprint button because walking is slow
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            velocity *= 2f;

        // Yeah
        rigidbody.MovePosition(rigidbody.position + velocity * SPEED);

        if (!circleSafe && !safe)
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

    public void LoadLevel(string name)
    {
        foreach (Transform g in GameObject.FindObjectsOfType<Transform>())
        {
            if (g.gameObject != gameObject)
                GameObject.Destroy(g.gameObject);
        }
        Debug.Log(name);
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }
}
