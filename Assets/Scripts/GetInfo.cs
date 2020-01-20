using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetInfo : MonoBehaviour {
    public Queue<Collider, int, int, int> laneQueue;
    public TrafficController trafficController;
    public GameObject gameObjectCross;
    private CrazyCarMovement crazyCarMovement;
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
    public int randomDirection;
    public int priorityAccordingToSigns;
    public int priority;
    public int lane;


    // Use this for initialization
    void Start ()
    {
       laneQueue = new Queue<Collider, int, int, int>();
    }
    //Here we settle what priority each Bot has.
    //The priority get decided by priorityAccordingToSigns(which is the priority that a Bot has according to the sign) and randomDirection(which is the direction that the bot will take).
    //If a bot is going to keep on going forward or turn right then its priority is the same as the priorityAccordingToSigns but if a bot is going to turn left then its priority is going to be priorityAccordingToSigns+1.
    //For example if a Bot A's  priorityAccordingToSigns is 2 because a different bot has highier priority  and its intenting to turn left then its priority is equal to 3.
    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("CrazyCar"))
        {
            crazyCarMovement = car.GetComponent<CrazyCarMovement>();
            int i = 0;
            if (RightRoad) i++;
            if (LeftRoad) i++;
            if (ForwardRoad) i++;
            randomDirection = Random.Range(1, i + 1);

            if (RightRoad == false)
                randomDirection = (randomDirection == 1) ? 2 : 3;
            if (LeftRoad == false)
                randomDirection = (randomDirection == 1) ? 1 : 3;
            crazyCarMovement.rng = randomDirection;
        }

        if (car.CompareTag("Bots"))
        {
            RightResult = (RightRoad && RightSigns) ? true : false;
            LeftResult = (LeftRoad && LeftSigns) ? true : false;
            ForwardResult = (ForwardRoad && ForwardSigns) ? true : false;
            int i = 0;
            if (RightResult) i++;
            if (LeftResult) i++;
            if (ForwardResult) i++;
            randomDirection = Random.Range(1, i + 1);

            if (RightResult == false)
                randomDirection = (randomDirection == 1) ? 2 : 3;
            if (LeftResult == false)
                randomDirection = (randomDirection == 1) ? 1 : 3;

            if (randomDirection == 2)
                priority = priorityAccordingToSigns + 1;
            else
                priority = priorityAccordingToSigns;

            Enqueue(car, randomDirection, priority, lane);
            carMovement = car.GetComponent<CarMovement>();
            carMovement.prio = priority;
            carMovement.rng = randomDirection;
            if (laneQueue.Count() == 1)
            {
                trafficController = gameObjectCross.GetComponent<TrafficController>();
                trafficController.Enqueue(car, randomDirection, priority, lane);
            }
        }
    }
    public void Dequeue()
    {
        laneQueue.Dequeue();
    }

    public void Enqueue(Collider name, int rng, int prio, int lane)
    {
        laneQueue.Enqueue(name, rng, prio, lane);
    }
   
}
