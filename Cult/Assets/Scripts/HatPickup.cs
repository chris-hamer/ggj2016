using UnityEngine;
using System.Collections;

public class HatPickup : MonoBehaviour {

    public Sprite up, down, left, right;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerControls>().hasHat = true;
            CharacterSprites sprites = collider.gameObject.GetComponent<CharacterSprites>();
            sprites.up = up;
            sprites.down = down;
            sprites.left = left;
            sprites.right = right;
            GameObject.Destroy(this.gameObject);
        }
    }

}
