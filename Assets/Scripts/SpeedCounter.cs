using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCounter : MonoBehaviour {

    CarControl carControl;
    Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            carControl = other.GetComponent<CarControl>();
            text = carControl.text.GetComponent<Text>();
            if (carControl.Speed * carControl.MovementInputValue > 60)
            {
                text.text = "Please slow down!";
            }
            else
            {
                text.text = "";
            }
        }
    }
}
