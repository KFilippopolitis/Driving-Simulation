using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAccident : MonoBehaviour
{
    public GameObject fire;
    public GameObject crazyCarFire;
    public GameObject bot;
    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;
    private void OnTriggerEnter(Collider other)
    {
        carMovement = bot.GetComponent<CarMovement>();
        crazyCarMovement = other.GetComponent<CrazyCarMovement>();

        if (other.CompareTag("CrazyCar"))
        {
            fire.SetActive(true);
            crazyCarFire.SetActive(true);
            carMovement.enabled = false;
            crazyCarMovement.enabled = false;
        }
    }
}
