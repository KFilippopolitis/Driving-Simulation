using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour {
    public PriorityQueue<Collider, int, float ,int> PriorityQueue;
    CarMovement carMovement;
    void Start () {
        PriorityQueue = new PriorityQueue<Collider, int, float, int>();
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    { carMovement = other.GetComponent<CarMovement>();
        if (other.CompareTag("Bots"))
        {
            PriorityQueue.Enqueue(other, 2, carMovement.Speed, 2);
        }
    }
    public void dequeuetre()
    {
        PriorityQueue.Dequeque();
    }
    public Collider getf() { return PriorityQueue.PeekName(); }
}
