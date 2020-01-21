﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyCarMovement : MonoBehaviour {

    public float Speed;                 // How fast the car moves forward and back.
    private Rigidbody Rigidbody;              // Reference used to move the car.
    private int turning;
    public int state = 4;
    private int temp = 0;
    public GameObject rightAlarm;
    public GameObject leftAlarm;
    public GameObject rightAlarmBack;
    public GameObject leftAlarmBack;
    public GameObject stop1;
    public GameObject stop2;
    public int rng;
    public int prio;
    public int count = 0;
    public float getpoint = 0;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }



    private void FixedUpdate()
    {

        Move();
        getpoint = Speed * Time.deltaTime + getpoint;
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
            Speed = 33f;
            turning = 90;
            if (getpoint >= 75)
            {
                Turn();
                getpoint = -100000000;
            }
        }
        else if (state == 2)
        {
            Speed = 34f;
            turning = -90;
            if (getpoint >= 103)
            {
                Turn();
                getpoint = -100000000;
            }
        }
        else if (state == 3)
            Speed = 34f;
    }

    private void Move()
    {
        // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
        Vector3 movement = transform.forward * Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position.
        Rigidbody.MovePosition(Rigidbody.position + movement);
    }

    public void turnStopOn(GameObject r)
    {
        Light a;
        a = r.GetComponent<Light>();
        a.enabled = true;
    }

    public void turnAlarmOn(GameObject r)
    {
        AlarmHandler a;
        a = r.GetComponent<AlarmHandler>();
        a.enabled = true;
    }

    public void turnLightsOff(GameObject r)
    {
        if (r != stop1 && r != stop2)
        {
            AlarmHandler a;
            a = r.GetComponent<AlarmHandler>();
            a.enabled = false;
        }
        Light b;
        b = r.GetComponent<Light>();
        b.enabled = false;
    }

    public void StopAllAlarms()
    {
        turnLightsOff(stop1);
        turnLightsOff(stop2);
        turnLightsOff(leftAlarm);
        turnLightsOff(leftAlarmBack);
        turnLightsOff(rightAlarm);
        turnLightsOff(rightAlarmBack);

    }
    private void Turn()
    {

        Quaternion turnRotation = Quaternion.Euler(0f, turning, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);

    }

    public void turnAround()
    {
        turning = -90;
        Turn();
    }
}
