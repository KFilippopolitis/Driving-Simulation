using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour {

    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bots"))
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.turnAround();
        }
        else if (other.CompareTag("Bots"))
        {
            crazyCarMovement = other.GetComponent<CrazyCarMovement>();
            crazyCarMovement.turnAround();
        }
    }
}
