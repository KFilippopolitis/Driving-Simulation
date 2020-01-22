using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyCarMovement : MonoBehaviour {
    public float timer;
    public float speed;                
    private Rigidbody rigidBody;              
    private int turning;
    public int state = 4;
    public GameObject rightAlarm;
    public GameObject leftAlarm;
    public GameObject rightAlarmBack;
    public GameObject leftAlarmBack;
    public GameObject stop1;
    public GameObject stop2;
    public int rng;
    public int prio;
    public float getpoint = 0;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        move();
        getpoint = speed * Time.deltaTime + getpoint;
        timer = Time.deltaTime * 2 + timer;
        if (timer > 4f)
        {
            speed = Random.Range(40, 100 + 1);
            timer = 0;
        }
    }

    void Update()
    {
        if (rng == 1)
        {
            turnAlarmOn(rightAlarm);
            turnAlarmOn(rightAlarmBack);
        }
        else if (rng == 2)
        {
            turnAlarmOn(leftAlarm);
            turnAlarmOn(leftAlarmBack);
        }
        
        if (state == 1)
        {
            speed = 33f;
            turning = 90;
            if (getpoint >= 75)
            {
                turn();
                getpoint = -100000000;
            }
        }
        else if (state == 2)
        {
            speed = 34f;
            turning = -90;
            if (getpoint >= 103)
            {
                turn();
                getpoint = -100000000;
            }
        }
        else if (state == 3)
            speed = 34f;
    }

    private void move()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rigidBody.MovePosition(rigidBody.position + movement);
    }

    public void turnStopOn(GameObject r)
    {
        Light a;
        a = r.GetComponent<Light>();
        a.enabled = true;
    }

    public void turnAlarmOn(GameObject r)
    {
        AlarmSwitcher a;
        a = r.GetComponent<AlarmSwitcher>();
        a.enabled = true;
    }

    public void turnLightsOff(GameObject r)
    {
        if (r != stop1 && r != stop2)
        {
            AlarmSwitcher a;
            a = r.GetComponent<AlarmSwitcher>();
            a.enabled = false;
        }
        Light b;
        b = r.GetComponent<Light>();
        b.enabled = false;
    }

    public void stopAllAlarms()
    {
        turnLightsOff(stop1);
        turnLightsOff(stop2);
        turnLightsOff(leftAlarm);
        turnLightsOff(leftAlarmBack);
        turnLightsOff(rightAlarm);
        turnLightsOff(rightAlarmBack);
    }
    private void turn()
    {
        Quaternion turnRotation = Quaternion.Euler(0f, turning, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);
    }

    public void turnAround()
    {
        turning = -90;
        turn();
    }
}
