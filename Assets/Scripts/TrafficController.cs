using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour {
    public PriorityQueue<Collider, int, int, int> priorityQueue;
    private CarMovement carMovement;
    private CrazyCarMovement crazyCarMovement;
    private int priority;
    public int firstwithpriority = 0;
    public Collider pastcollider;
    public Collider col;
    public GameObject lane1;
    public GameObject lane2;
    public GameObject lane3;
    public GameObject lane4;
    GetInfo getInfo1;
    GetInfo getInfo2;
    GetInfo getInfo3;
    GetInfo getInfo4;
    public int count = 0;
    private int lane;

    private void Update()
    {
        if (priorityQueue.Count() != 0)
        {
            count = priorityQueue.Count();
            col = priorityQueue.PeekName();
        }
    }
    void Start()
    {
        priorityQueue = new PriorityQueue<Collider, int, int, int>();
        getInfo1 = lane1.GetComponent<GetInfo>();
        getInfo2 = lane2.GetComponent<GetInfo>();
        getInfo3 = lane3.GetComponent<GetInfo>();
        getInfo4 = lane4.GetComponent<GetInfo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        carMovement = other.GetComponent<CarMovement>();
        if (other.CompareTag("Bots"))
        {
            carMovement.getpoint = 0;
            carMovement.Speed = 0;
            carMovement.turnStopOn(carMovement.stop1);
            carMovement.turnStopOn(carMovement.stop2);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        carMovement = other.GetComponent<CarMovement>();
        if (priorityQueue.Count() != 0 && other == priorityQueue.PeekName() && firstwithpriority == 0)
        {
            if (other.CompareTag("Bots"))
            { 
                priority = priorityQueue.PeekPriority();
                carMovement.state = priorityQueue.PeekRng();
                carMovement.turnLightsOff(carMovement.stop1);
                carMovement.turnLightsOff(carMovement.stop2);
                pastcollider = other;
                lane = priorityQueue.PeekLane();
                QueueAndDequeue(priorityQueue.PeekLane());
            }
           
            if (priorityQueue.Count() != 0 )
                if (priority!= priorityQueue.PeekPriority() || (priority % 2 == 0 && lane != priorityQueue.PeekLane()))
                    firstwithpriority++;
        }
        if (other.CompareTag("CrazyCar"))
        {
            crazyCarMovement = other.GetComponent<CrazyCarMovement>();
            crazyCarMovement.state = crazyCarMovement.rng;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bots"))
        {
            carMovement = other.GetComponent<CarMovement>();
            carMovement.Speed = 33f;
            carMovement.state = 4;
            carMovement.count = 0;
            carMovement.rng = 0;
            carMovement.turnLightsOff(carMovement.leftAlarm);
            carMovement.turnLightsOff(carMovement.leftAlarmBack);
            carMovement.turnLightsOff(carMovement.rightAlarm);
            carMovement.turnLightsOff(carMovement.rightAlarmBack);
            if (pastcollider == other)
            {
                firstwithpriority = 0;
            }
        }
        else if(other.CompareTag("CrazyCar"))
        {
            crazyCarMovement = other.GetComponent<CrazyCarMovement>();
            crazyCarMovement.turnLightsOff(crazyCarMovement.leftAlarm);
            crazyCarMovement.turnLightsOff(crazyCarMovement.leftAlarmBack);
            crazyCarMovement.turnLightsOff(crazyCarMovement.rightAlarm);
            crazyCarMovement.turnLightsOff(crazyCarMovement.rightAlarmBack);
            crazyCarMovement.Speed = 33f;
            crazyCarMovement.state = 4;
            crazyCarMovement.rng = 0;
            crazyCarMovement.count = 0;
        }
    }

    public void Dequeue()
    {
        priorityQueue.Dequeque();
    }

    public void Enqueue(Collider name, int rng, int prio, int lane)
    {
        priorityQueue.Enqueue(name, rng, prio, lane);
    }

    public void getYourTime()
    {
        firstwithpriority = 0;
    }

    private void QueueAndDequeue (int lane)
    {
        if (lane == getInfo1.lane)
        {
            Dequeue();
            getInfo1.Dequeue();
            if (getInfo1.Queue.Count() != 0)
            {
                Enqueue(getInfo1.Queue.PeekName(), getInfo1.Queue.PeekRng(), getInfo1.Queue.PeekPriority(), getInfo1.Queue.PeekLane());
            }
        }
        else if (lane == getInfo2.lane)
        {
            Dequeue();
            getInfo2.Dequeue();
            if (getInfo2.Queue.Count() != 0)
            {
                Enqueue(getInfo2.Queue.PeekName(), getInfo2.Queue.PeekRng(), getInfo2.Queue.PeekPriority(), getInfo2.Queue.PeekLane());
            }
        }
        else if (lane == getInfo3.lane)
        {
            Dequeue();
            getInfo3.Dequeue();
            if (getInfo3.Queue.Count() != 0)
            {
                Enqueue(getInfo3.Queue.PeekName(), getInfo3.Queue.PeekRng(), getInfo3.Queue.PeekPriority(), getInfo3.Queue.PeekLane());
            }
        }
        else if (lane == getInfo4.lane)
        {
            Dequeue();
            getInfo4.Dequeue();
            if (getInfo4.Queue.Count() != 0)
            {
                Enqueue(getInfo4.Queue.PeekName(), getInfo4.Queue.PeekRng(), getInfo4.Queue.PeekPriority(), getInfo4.Queue.PeekLane());
            }
        }
    }
}
