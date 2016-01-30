using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour {

    public static string[][] scenes =
        {
          new string[] { "",            "",            "",             "hats",         "footprints3" },
          new string[] { "",            "",            "rectangle3",   "footprints1",  "footprints2" },
          new string[] { "tutorial2",   "rectangle1",  "rectangle2",   "",             ""            },
          new string[] { "tutorial1",   "",            "",             "",             ""            },
        };

    public static Vector2 index = new Vector2(0, 2);
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
            player.position -= direction.normalized * (direction.x != 0 ? 13 : 7);
            direction.y *= -1;
            index += direction;
            SceneManager.LoadScene("Scenes/" + scenes[(int)index.y][(int)index.x]);
        }
    }
}
