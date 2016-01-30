using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelTransition : MonoBehaviour {

    public static string[][] scenes =
        {
          new string[] { "",            "",            "",             "end",          ""            },
          new string[] { "",            "",            "",             "dev-order3",   ""            },
          new string[] { "",            "",            "",             "dev-order2",   ""            },
          new string[] { "",            "",            "",             "dev-order1",   ""            },
          new string[] { "",            "",            "hat",          "hats",         "footprints3" },
          new string[] { "",            "",            "rectangle3",   "footprints1",  "footprints2" },
          new string[] { "tutorial2",   "rectangle1",  "rectangle2",   "",             ""            },
          new string[] { "tutorial1",   "",            "",             "",             ""            }
        };

    public static Vector2 index = new Vector2(0, 7);
    public Vector2 direction;

    public float transitionTime = 0f;

    private Rigidbody2D player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (transitionTime > 0)
            transitionTime -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && transitionTime <= 0f)
        {
            transitionTime = 0.5f;
            player.position -= direction.normalized * (direction.x != 0 ? 13 : 7);
            direction.y *= -1;
            index += direction;

            player.GetComponent<PlayerControls>().LoadLevel(scenes[(int)index.y][(int)index.x]);
        }
    }
}
