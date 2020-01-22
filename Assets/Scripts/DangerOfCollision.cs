using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DangerOfCollision : MonoBehaviour {

    CarMovement carMovement;
    private float speed = 40f;
    //The class DangerOfCollision is an imitation of a system that prevents cars from colliding 

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Bots"))
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.turnStopOn(carMovement.stop2);
            carMovement.turnStopOn(carMovement.stop1);
            if (speed > 1f)
            {
                if (carMovement != null)
                {
                    carMovement.speed -= 1f;
                    speed = carMovement.speed;
                }
            }
            else
            {
                if (carMovement != null)
                {
                    carMovement = other.GetComponent<CarMovement>();
                    carMovement.speed = 0;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bots")) 
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.speed = 33f;
            carMovement.turnLightsOff(carMovement.stop1);
            carMovement.turnLightsOff(carMovement.stop2);
        }
    }
}
