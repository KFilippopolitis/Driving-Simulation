using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RESPAWN : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawingpoint;
   
    


    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawingpoint.transform.position;
        player.transform.rotation = respawingpoint.transform.rotation;
    }
}
