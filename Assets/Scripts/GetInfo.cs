using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetInfo : MonoBehaviour {
    public Queue<Collider, int, int, int> Queue;
    public TrafficController trafficController;
    public GameObject gameObjectCross;
    CarMovement carMovement;
    public bool RightRoad;
    public bool LeftRoad;
    public bool ForwardRoad;
    public bool RightSigns;
    public bool LeftSigns;
    public bool ForwardSigns;
    public bool RightResult;
    public bool LeftResult;
    public bool ForwardResult;
    public int rng;
    public int priorityAccordingToSigns;
    public int priority;
    public int lane;


    // Use this for initialization
    void Start ()
    {
       Queue = new Queue<Collider, int, int, int>();
    }

    // Update is called once per frame
    void Update () {
       
       
	}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CarControl carControl;
            carControl = other.GetComponent<CarControl>();
            if (carControl.rng == 2)
            {
                priority = priorityAccordingToSigns + 1;
            }
            else
            {
                priority = priorityAccordingToSigns;
            }
            Enqueue(other, carControl.rng, priority, lane);
            if (Queue.Count() == 1)
            {
                trafficController = gameObjectCross.GetComponent<TrafficController>();
                trafficController.Enqueue(other, carControl.rng, priority, lane);
            }
        }

        if (other.CompareTag("Bots"))
        {
            RightResult = (RightRoad && RightSigns) ? true : false;
            LeftResult = (LeftRoad && LeftSigns) ? true : false;
            ForwardResult = (ForwardRoad && ForwardSigns) ? true : false;
            int i = 0;
            if (RightResult) i++;
            if (LeftResult) i++;
            if (ForwardResult) i++;
            rng = Random.Range(1, i + 1);

            if (RightResult == false)
            {
                rng = (rng == 1) ? 2 : 3;
            }
            if (LeftResult == false)
            {
                rng = (rng == 1) ? 1 : 3;
            }

            if (rng == 2)
            {
                priority = priorityAccordingToSigns + 1;
            }
            else
            {
                priority = priorityAccordingToSigns;
            }

            Enqueue(other, rng, priority, lane);
            carMovement = other.GetComponent<CarMovement>();
            carMovement.prio = priority;
            carMovement.rng = rng;
            if (Queue.Count() == 1)
            {
                trafficController = gameObjectCross.GetComponent<TrafficController>();
                trafficController.Enqueue(other, rng, priority, lane);
            }
        }
    }
    public void Dequeue()
    {
        Queue.Dequeque();
    }

    public void Enqueue(Collider name, int rng, int prio, int lane)
    {
        Queue.Enqueue(name, rng, prio, lane);
    }
   
}
