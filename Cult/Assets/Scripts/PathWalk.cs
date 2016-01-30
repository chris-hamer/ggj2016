using UnityEngine;
using System.Collections;

public class PathWalk : MonoBehaviour {

    public float MinStoppingDistance = 0.1f; // Radius for when the person has reached this point
    
    public int IndexNextPathNode = 0; // Index of the next node in the path
    public Transform[] ListPathNodeTransforms;
    /* In the editor, define the path by drag-dropping the transforms of the path nodes
        that are in the scene. The PathNode script objects are then stored, and the PathWalk script
        will use those as locations of the path to walk.
    */
    public bool DoesPathLoop = false;

    [HideInInspector] new public Transform transform; // cache
    [HideInInspector] new public Rigidbody2D rigidbody; // cache

    private PathNode[] pathNodeList = null;
    private float speed = PlayerControls.SPEED; // Moves at same speed as the player
    private float waitTimer = 0.0f;
    private bool isWalking = true;

	void Start ()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        pathNodeList = new PathNode[ListPathNodeTransforms.Length];
        for (int ii=0; ii<ListPathNodeTransforms.Length; ii++)
        {
            pathNodeList[ii] = ListPathNodeTransforms[ii].GetComponent<PathNode>();
        }
    }
	
	void Update () {
        // Are we waiting at the current point?
        if (waitTimer > 0.0f)
        {
            waitTimer -= Time.deltaTime;
        }
        else // We are moving between points.
        {
            Vector2 difference = pathNodeList[IndexNextPathNode].Position - rigidbody.position;
            // Keep moving unless we reach the destination.
            if (difference.magnitude > MinStoppingDistance)
            {
                rigidbody.MovePosition(rigidbody.position + difference.normalized * PlayerControls.SPEED);
            }
            else
            {
                waitTimer = pathNodeList[IndexNextPathNode].WaitDuration;
                IndexNextPathNode++;
                if (DoesPathLoop) // Not all paths loop
                    IndexNextPathNode = IndexNextPathNode % pathNodeList.Length;
            }
        }        
	}
}
