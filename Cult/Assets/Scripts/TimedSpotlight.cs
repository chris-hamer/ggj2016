using UnityEngine;
using System.Collections;

public class TimedSpotlight : MonoBehaviour {

    public float DelayTime = 0.0f;
    public float DurationActive = 1.0f;
    public float FadeOutTime = 1.0f;
    [HideInInspector] new public Light light;

    private float fadingOutTime;
    private float originalIntensity;

	void Start () {
        light = GetComponent<Light>();
        originalIntensity = light.intensity;
        light.enabled = false;
        fadingOutTime = FadeOutTime;
    }
	
	void Update () {
	    if (DelayTime > 0.0f) {
            // Light hasn't appeared yet
            DelayTime -= Time.deltaTime;
            if (DelayTime <= 0.0f) {
                light.enabled = true;
            }
        }
        else if (DurationActive > 0.0f) {
            // Light is currently active
            DurationActive -= Time.deltaTime;
        }
        else if (FadeOutTime > 0.0f) {
            // Fading out
            fadingOutTime -= Time.deltaTime;
            light.intensity = (fadingOutTime/FadeOutTime) * originalIntensity;
        }
	}
}
