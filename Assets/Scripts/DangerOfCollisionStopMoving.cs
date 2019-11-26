using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerOfCollisionStopMoving : MonoBehaviour {

    private CarMovement carMovement;
    private CarControl carControl;
    private float speed = 40f;
    Text text;

    // Use this for initialization
    void Start()
    {

    }
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            carControl = other.GetComponent<CarControl>();
            carControl.ChangeText("Please Slow down you are too close !");
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            carControl = other.GetComponent<CarControl>();
            //carControl.ChangeText("aaaaaaaaaaaaaa");
        }

        if (other.CompareTag("Bots")) 
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.Speed = 33f;
            carMovement.turnLightsOff(carMovement.stop1);
            carMovement.turnLightsOff(carMovement.stop2);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
