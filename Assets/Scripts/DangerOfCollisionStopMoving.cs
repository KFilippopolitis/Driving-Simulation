using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerOfCollisionStopMoving : MonoBehaviour {

    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;
    private float speed = 40f;

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
                    carMovement.Speed -= 1f;
                    speed = carMovement.Speed;
                }
            }
            else
            {
                if (carMovement != null)
                {
                    carMovement = other.GetComponent<CarMovement>();
                    carMovement.Speed = 0;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bots")) 
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.Speed = 33f;
            carMovement.turnLightsOff(carMovement.stop1);
            carMovement.turnLightsOff(carMovement.stop2);
        }
        else if (other.CompareTag("CrazyCar"))
        {
            crazyCarMovement = other.GetComponent<CrazyCarMovement>();
            crazyCarMovement.speed = 33f;
            crazyCarMovement.turnLightsOff(crazyCarMovement.stop1);
            crazyCarMovement.turnLightsOff(crazyCarMovement.stop2);
        }
    }
}
