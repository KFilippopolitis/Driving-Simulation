using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour {

    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bots"))
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.turnAround();
        }
        else if (other.CompareTag("CrazyCar"))
        {
            crazyCarMovement = other.GetComponent<CrazyCarMovement>();
            crazyCarMovement.turnAround();
        }
    }
}
