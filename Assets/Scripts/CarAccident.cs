using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAccident : MonoBehaviour {
    public GameObject fire;

    private void OnTriggerEnter(Collider other)
    {
        fire.SetActive(true);
        fire.transform.position = other.transform.position;
        fire.transform.Translate(0, 6, -10);
    }
}
