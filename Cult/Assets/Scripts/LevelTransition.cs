using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

    public static string[][] scenes = 
        { new string[] { "rectangle1", "footprints", } };

    public static Vector2 index = Vector2.zero;
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
            player.position -= direction.normalized * 13;
            Application.LoadLevel(scenes[(int)index.y][(int)index.x]);
        }
    }
}
