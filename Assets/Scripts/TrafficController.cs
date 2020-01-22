using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour {
    public PriorityQueue<Collider, int, int, int> crossQueue;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    private CarMovement carMovement;
    private CrazyCarMovement crazyCarMovement;
    private int priority;
    private int carCanMove = 1;
    private Collider carInTheIntersection;
    LaneQueue laneQueue1;
    LaneQueue laneQueue2;
    LaneQueue laneQueue3;
    LaneQueue laneQueue4;
    private int lane;

    void Start()
    {
        crossQueue = new PriorityQueue<Collider, int, int, int>();
        laneQueue1 = lane1.GetComponent<LaneQueue>();
        laneQueue2 = lane2.GetComponent<LaneQueue>();
        laneQueue3 = lane3.GetComponent<LaneQueue>();
        laneQueue4 = lane4.GetComponent<LaneQueue>();
    }

    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Bots"))
        {
            carMovement = car.GetComponent<CarMovement>();
            carMovement.getpoint = 0;
            carMovement.speed = 0;
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
        if (crossQueue.count() != 0 && car == crossQueue.peekName() && carCanMove == 1)
        {
            if (car.CompareTag("Bots"))
            { 
                priority = crossQueue.peekPriority();
                carMovement.state = crossQueue.peekRng();
                carMovement.turnLightsOff(carMovement.stop1);
                carMovement.turnLightsOff(carMovement.stop2);
                carInTheIntersection = car;
                lane = crossQueue.peekLane();
                carIsInTheIntersection(lane);
            }
           
            if (crossQueue.count() != 0 )
                if (priority!= crossQueue.peekPriority() || ((priority % 2 == 0 )&& (lane != crossQueue.peekLane())))
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
            carMovement.speed = 33f;
            carMovement.state = 4;
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
            crossQueue.dequeue();
            laneQueue1.laneQueue.dequeue();
            if (laneQueue1.laneQueue.count() != 0)
            {
                crossQueue.enqueue(laneQueue1.laneQueue.peekName(), laneQueue1.laneQueue.peekRng(), laneQueue1.laneQueue.peekPriority(), laneQueue1.laneQueue.peekLane());
            }
        }
        else if (lane == laneQueue2.lane)
        {
            crossQueue.dequeue();
            laneQueue2.laneQueue.dequeue();
            if (laneQueue2.laneQueue.count() != 0)
            {
                crossQueue.enqueue(laneQueue2.laneQueue.peekName(), laneQueue2.laneQueue.peekRng(), laneQueue2.laneQueue.peekPriority(), laneQueue2.laneQueue.peekLane());
            }
        }
        else if (lane == laneQueue3.lane)
        {
            crossQueue.dequeue();
            laneQueue3.laneQueue.dequeue();
            if (laneQueue3.laneQueue.count() != 0)
            {
                crossQueue.enqueue(laneQueue3.laneQueue.peekName(), laneQueue3.laneQueue.peekRng(), laneQueue3.laneQueue.peekPriority(), laneQueue3.laneQueue.peekLane());
            }
        }
        else if (lane == laneQueue4.lane)
        {
            crossQueue.dequeue();
            laneQueue4.laneQueue.dequeue();
            if (laneQueue4.laneQueue.count() != 0)
            {
                crossQueue.enqueue(laneQueue4.laneQueue.peekName(), laneQueue4.laneQueue.peekRng(), laneQueue4.laneQueue.peekPriority(), laneQueue4.laneQueue.peekLane());
            }
        }
    }
}
