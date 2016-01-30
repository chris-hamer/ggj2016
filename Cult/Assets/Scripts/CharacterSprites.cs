using UnityEngine;
using System.Collections;

public class CharacterSprites : MonoBehaviour {

    public Sprite up, down, left, right;

    new private SpriteRenderer renderer;
    new private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start ()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        SetDirection(Vector2.down);
	}

    public void SetDirection(Vector2 direction)
    {
        if (direction.y < 0)
            renderer.sprite = down;
        else if (direction.y > 0)
            renderer.sprite = up;

        else if (direction.x > 0)
            renderer.sprite = right;
        else if (direction.x < 0)
            renderer.sprite = left;
    }
}
