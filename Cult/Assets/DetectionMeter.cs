using UnityEngine;
using System.Collections;

public class DetectionMeter : MonoBehaviour {

    public PlayerControls player;
    public RectTransform meter;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update () {
        meter.localScale = new Vector3(player.detection, 1, 1);
	}
}
