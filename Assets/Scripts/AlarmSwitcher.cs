using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSwitcher : MonoBehaviour {

    Light lights;
    private int i = 0;

	void Start () 
    {
        lights = gameObject.GetComponent<Light>();
	}
	
	void Update () {
        if (i%20 <10)
            lights.enabled = false;
        else
            lights.enabled = true;
        i++;
	}
}
