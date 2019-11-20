using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {
    public GameObject game; 
    TEst est;
    public Collider a;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        est = game.GetComponent<TEst>();
        a=est.getf();
        est.dequeuetre();
    }
}
