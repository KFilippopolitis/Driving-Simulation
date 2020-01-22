using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAccident : MonoBehaviour
{
    public GameObject fireAnimation;
    public GameObject crazyCarFireAnimation;
    public GameObject bot;
    CarMovement carMovement;
    CrazyCarMovement crazyCarMovement;
    private void OnTriggerEnter(Collider other)
    {
        carMovement = bot.GetComponent<CarMovement>();
        crazyCarMovement = other.GetComponent<CrazyCarMovement>();

        if (other.CompareTag("CrazyCar"))
        {
            fireAnimation.SetActive(true);
            crazyCarFireAnimation.SetActive(true);
            carMovement.enabled = false;
            crazyCarMovement.enabled = false;
        }
    }
}
