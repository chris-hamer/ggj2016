using UnityEngine;
using System.Collections;

public class SequenceObject : MonoBehaviour {

    public Transform[] SequenceNodeTransforms;
    public bool ResetOnFail = false;

    private bool isComplete = false;
    public bool IsComplete {  get { return isComplete; } }

    private SequenceNode[] sequenceNodes;
    private PlayerControls playerControls;
    private int sequenceLength;
    private int sequencePosition = 0;

    // Use this for initialization
    void Start () {
        playerControls = GameObject.FindObjectOfType<PlayerControls>();
        sequenceLength = SequenceNodeTransforms.Length;
        sequenceNodes = new SequenceNode[sequenceLength];
        for (int ii = 0; ii < sequenceLength; ii++) {
            sequenceNodes[ii] = SequenceNodeTransforms[ii].GetComponent<SequenceNode>();
            sequenceNodes[ii].SetOwner(this);
        }
	}

    public void ActivateTrigger(SequenceNode node) {
        if (node==sequenceNodes[sequencePosition]) {
            sequencePosition++;
            if (sequencePosition == sequenceLength) {
                isComplete = true;
                sequencePosition = 0; // what happens if you walk back?
                Debug.Log("Sequence completed!");
            }
        }
        else {
            Debug.Log("Wrong sequence trigger!");
            // tell playerControls to increase detection / set as unsafe
            if (ResetOnFail) {
                sequencePosition = 0;
            }
        }
    }

}
