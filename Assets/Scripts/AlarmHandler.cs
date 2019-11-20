using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmHandler : MonoBehaviour {
    Light lights;
    private int i = 0;
	// Use this for initialization
	void Start () {
        lights = gameObject.GetComponent<Light>();
        lights.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (i%20 <10)
        {
            lights.enabled = false;
        }
        else
        {
            lights.enabled = true;
        }
        i++;
	}
}
