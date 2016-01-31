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
    public bool controlsEnabled;

    public static GameObject player;
    public Vector2 velocity;

    private Vector2 startPos;
    private string currentScene;

    void Awake() {
        currentScene = "tutorial1";
        rigidbody = GetComponent<Rigidbody2D>();
        sprites = GetComponent<CharacterSprites>();
    }

    // Use this for initialization
    void Start()
    {
        controlsEnabled = true;
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
        // Move using keyboard input
        velocity = Vector2.zero;

        if (controlsEnabled)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                velocity += Vector2.up;
            if (Input.GetKey(KeyCode.DownArrow))
                velocity += Vector2.down;
            if (Input.GetKey(KeyCode.LeftArrow))
                velocity += Vector2.left;
            if (Input.GetKey(KeyCode.RightArrow))
                velocity += Vector2.right;
            velocity.Normalize();
        }

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
            if (controlsEnabled)
            {
                controlsEnabled = false;
                StartCoroutine(Die());
            }
        }
    }

    public void LoadLevel(string name)
    {
        startPos = rigidbody.position;
        foreach (Transform g in GameObject.FindObjectsOfType<Transform>())
        {
            if (g.gameObject != gameObject)
                GameObject.Destroy(g.gameObject);
        }
        currentScene = name;
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    IEnumerator Die()
    {
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        while (r.color.a > 0)
        {
            r.color = new Color(1, 0, 0, r.color.a - 2 * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        controlsEnabled = true;
        rigidbody.position = startPos;
        detection = 0f;
        r.color = new Color(1, 1, 1, 1);
        safe = true;
        circleSafe = true;
        SceneManager.LoadScene(currentScene);
        //SceneManager.LoadScene("tutorial1");
    }
}
