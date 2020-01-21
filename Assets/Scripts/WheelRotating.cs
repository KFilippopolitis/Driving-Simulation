using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotating : MonoBehaviour//change to WheelRotation 
{
    public GameObject car;
    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;

    void Update()
    {
        if (car.CompareTag("Bots")) 
        {
            carMovement = car.GetComponent<CarMovement>();
            transform.Rotate(Vector3.right * Time.deltaTime *3* carMovement.Speed);
        }
        if (car.CompareTag("CrazyCar"))
        {
            crazyCarMovement = car.GetComponent<CrazyCarMovement>();
            transform.Rotate(Vector3.right * Time.deltaTime * crazyCarMovement.speed*3);
        }
    }
}
