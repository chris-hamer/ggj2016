using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour {

    public static string[][] scenes =
        { new string[] { "",            "circles",      "footprints1",  "footprints2" },
          new string[] { "rectangle1",  "rectangle2",   "",             "" } };

    public static Vector2 index = new Vector2(0, 1);
    public Vector2 direction;

    private Rigidbody2D player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            direction.y *= -1;
            index += direction;
            player.position -= direction.normalized * (direction.x != 0 ? 13 : 7);
            SceneManager.LoadScene("Scenes/" + scenes[(int)index.y][(int)index.x]);
        }
    }
}
