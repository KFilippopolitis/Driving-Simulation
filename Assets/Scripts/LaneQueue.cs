using UnityEngine;


public class LaneQueue : MonoBehaviour {
    public Queue<Collider, int, int, int> laneQueue;
    public TrafficController trafficController;
    public GameObject gameObjectCross;
    private CrazyCarMovement crazyCarMovement;
    CarMovement carMovement;
    public bool rightRoad;
    public bool leftRoad;
    public bool forwardRoad;
    public bool rightSigns;
    public bool leftSigns;
    public bool forwardSigns;
    public bool rightResult;
    public bool leftResult;
    public bool forwardResult;
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
            if (rightRoad) i++;
            if (leftRoad) i++;
            if (forwardRoad) i++;
            randomDirection = Random.Range(1, i + 1);

            if (rightRoad == false)
                randomDirection = (randomDirection == 1) ? 2 : 3;
            if (leftRoad == false)
                randomDirection = (randomDirection == 1) ? 1 : 3;
            crazyCarMovement.crazyCarDirection = randomDirection;
        }

        if (car.CompareTag("Bots"))
        {
            rightResult = (rightRoad && rightSigns) ? true : false;
            leftResult = (leftRoad && leftSigns) ? true : false;
            forwardResult = (forwardRoad && forwardSigns) ? true : false;
            int i = 0;
            if (rightResult) i++;
            if (leftResult) i++;
            if (forwardResult) i++;
            randomDirection = Random.Range(1, i + 1);

            if (rightResult == false)
                randomDirection = (randomDirection == 1) ? 2 : 3;
            if (leftResult == false)
                randomDirection = (randomDirection == 1) ? 1 : 3;

            if (randomDirection == 2)
                priority = priorityAccordingToSigns + 1;
            else
                priority = priorityAccordingToSigns;

            laneQueue.enqueue(car, randomDirection, priority, lane);
            carMovement = car.GetComponent<CarMovement>();
            carMovement.botDirection = priority;
            carMovement.rng = randomDirection;
            if (laneQueue.count() == 1)
            {
                trafficController = gameObjectCross.GetComponent<TrafficController>();
                trafficController.crossQueue.enqueue(car, randomDirection, priority, lane);
            }
        }
    }
}
