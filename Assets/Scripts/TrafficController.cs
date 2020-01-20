using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour {
    public PriorityQueue<Collider, int, int, int> crossQueue;
    private CarMovement carMovement;
    private CrazyCarMovement crazyCarMovement;
    private int priority;
    public int carCanMove = 1;
    public Collider carInTheIntersection;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    GetInfo laneQueue1;
    GetInfo laneQueue2;
    GetInfo laneQueue3;
    GetInfo laneQueue4;
    private int lane;

    void Start()
    {
        crossQueue = new PriorityQueue<Collider, int, int, int>();
        laneQueue1 = lane1.GetComponent<GetInfo>();
        laneQueue2 = lane2.GetComponent<GetInfo>();
        laneQueue3 = lane3.GetComponent<GetInfo>();
        laneQueue4 = lane4.GetComponent<GetInfo>();
    }

    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Bots"))
        {
            carMovement = car.GetComponent<CarMovement>();
            carMovement.getpoint = 0;
            carMovement.Speed = 0;
            carMovement.turnStopOn(carMovement.stop1);
            carMovement.turnStopOn(carMovement.stop2);

        }
        else if (car.CompareTag("CrazyCar"))
        {
            crazyCarMovement= car.GetComponent<CrazyCarMovement>();
            crazyCarMovement.getpoint = 0;
            crazyCarMovement.speed = 0;
            crazyCarMovement.turnStopOn(crazyCarMovement.stop1);
            crazyCarMovement.turnStopOn(crazyCarMovement.stop2);

        }
    }
    private void OnTriggerStay(Collider car)
    {
        carMovement = car.GetComponent<CarMovement>();
        if (crossQueue.Count() != 0 && car == crossQueue.PeekName() && carCanMove == 1)
        {
            if (car.CompareTag("Bots"))
            { 
                priority = crossQueue.PeekPriority();
                carMovement.state = crossQueue.PeekRng();
                carMovement.turnLightsOff(carMovement.stop1);
                carMovement.turnLightsOff(carMovement.stop2);
                carInTheIntersection = car;
                lane = crossQueue.PeekLane();
                carIsInTheIntersection(lane);
            }
           
            if (crossQueue.Count() != 0 )
                if (priority!= crossQueue.PeekPriority() || ((priority % 2 == 0 )&& (lane != crossQueue.PeekLane())))
                    carCanMove=0;
        }
        if (car.CompareTag("CrazyCar"))
        {
            crazyCarMovement = car.GetComponent<CrazyCarMovement>();
            crazyCarMovement.state = crazyCarMovement.rng;
        }
    }

    private void OnTriggerExit(Collider car)
    {
        if (car.CompareTag("Bots"))
        {
            carMovement = car.GetComponent<CarMovement>();
            carMovement.Speed = 33f;
            carMovement.state = 4;
            carMovement.count = 0;
            carMovement.rng = 0;
            carMovement.turnLightsOff(carMovement.leftAlarm);
            carMovement.turnLightsOff(carMovement.leftAlarmBack);
            carMovement.turnLightsOff(carMovement.rightAlarm);
            carMovement.turnLightsOff(carMovement.rightAlarmBack);
            if (carInTheIntersection == car)
            {
                carCanMove = 1;
            }
        }
        else if(car.CompareTag("CrazyCar"))
        {
            crazyCarMovement = car.GetComponent<CrazyCarMovement>();
            crazyCarMovement.speed = 33f;
            crazyCarMovement.state = 4;
            crazyCarMovement.count = 0;
            crazyCarMovement.rng = 0;
            crazyCarMovement.turnLightsOff(crazyCarMovement.leftAlarm);
            crazyCarMovement.turnLightsOff(crazyCarMovement.leftAlarmBack);
            crazyCarMovement.turnLightsOff(crazyCarMovement.rightAlarm);
            crazyCarMovement.turnLightsOff(crazyCarMovement.rightAlarmBack);
        }
    }

    private void carIsInTheIntersection (int lane)
    {
        if (lane == laneQueue1.lane)
        {
            crossQueue.Dequeue();
            laneQueue1.Dequeue();
            if (laneQueue1.Queue.Count() != 0)
            {
                crossQueue.Enqueue(laneQueue1.Queue.PeekName(), laneQueue1.Queue.PeekRng(), laneQueue1.Queue.PeekPriority(), laneQueue1.Queue.PeekLane());
            }
        }
        else if (lane == laneQueue2.lane)
        {
            crossQueue.Dequeue();
            laneQueue2.Dequeue();
            if (laneQueue2.Queue.Count() != 0)
            {
                crossQueue.Enqueue(laneQueue2.Queue.PeekName(), laneQueue2.Queue.PeekRng(), laneQueue2.Queue.PeekPriority(), laneQueue2.Queue.PeekLane());
            }
        }
        else if (lane == laneQueue3.lane)
        {
            crossQueue.Dequeue();
            laneQueue3.Dequeue();
            if (laneQueue3.Queue.Count() != 0)
            {
                crossQueue.Enqueue(laneQueue3.Queue.PeekName(), laneQueue3.Queue.PeekRng(), laneQueue3.Queue.PeekPriority(), laneQueue3.Queue.PeekLane());
            }
        }
        else if (lane == laneQueue4.lane)
        {
            crossQueue.Dequeue();
            laneQueue4.Dequeue();
            if (laneQueue4.Queue.Count() != 0)
            {
                crossQueue.Enqueue(laneQueue4.Queue.PeekName(), laneQueue4.Queue.PeekRng(), laneQueue4.Queue.PeekPriority(), laneQueue4.Queue.PeekLane());
            }
        }
    }
}
