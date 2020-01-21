using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESPAWN : MonoBehaviour {

    private Transform player;
    private Transform respawingpoint;




    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawingpoint.transform.position;
            player.transform.rotation = respawingpoint.transform.rotation;
        }
    }
}
