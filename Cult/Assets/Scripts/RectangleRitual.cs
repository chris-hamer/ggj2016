using UnityEngine;
using System.Collections;

public class RectangleRitual : MonoBehaviour {

    public Transform[] targets;
    public int currentTarget;
    private float time;
    new private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        time = 0f;
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = ((Vector2)targets[currentTarget].position - rigidbody.position).normalized;
        rigidbody.MovePosition(rigidbody.position + dir * Player.SPEED);

        if (currentTarget == 1 && rigidbody.position.x >= targets[currentTarget].position.x ||
            currentTarget == 2 && rigidbody.position.y <= targets[currentTarget].position.y ||
            currentTarget == 3 && rigidbody.position.x <= targets[currentTarget].position.x ||
            currentTarget == 0 && rigidbody.position.y >= targets[currentTarget].position.y)
        {
            GetNextTarget();
        }
    }

    private void GetNextTarget()
    {
        rigidbody.position = targets[currentTarget].position;
        currentTarget++;
        if (currentTarget >= targets.Length)
            currentTarget = 0;
    }
}
