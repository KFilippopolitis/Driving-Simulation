using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public GameObject car;
    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;

    //WheelRotation is representing a wheel rotation according to the speed of the car.
    void Update()
    {
        if (car.CompareTag("Bots")) 
        {
            carMovement = car.GetComponent<CarMovement>();
            transform.Rotate(Vector3.right * Time.deltaTime *3* carMovement.speed);
        }
        if (car.CompareTag("CrazyCar"))
        {
            crazyCarMovement = car.GetComponent<CrazyCarMovement>();
            transform.Rotate(Vector3.right * Time.deltaTime * crazyCarMovement.speed*3);
        }
    }
}
