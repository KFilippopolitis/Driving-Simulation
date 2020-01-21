using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHour : MonoBehaviour {
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;
    public GameObject car7;
    public GameObject car8;
    public GameObject car9;
    public GameObject car10;
    public GameObject car11;
    public GameObject car12;
    public GameObject car13;
    public GameObject car14;
    public GameObject car15;
    public GameObject car16;
    public float timer;
    private int cameraId = 1;
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    void Start() 
    {
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera(cameraId);
            cameraId++;
        }

        timer = Time.deltaTime + timer;
        if (timer > 5)
        {
            car1.SetActive(true);
            car2.SetActive(true);
        }
        if (timer > 10)
        {
            car3.SetActive(true);
            car4.SetActive(true);
        }
        if (timer > 15)
        {
            car5.SetActive(true);
            car6.SetActive(true);
        }
        if (timer > 20)
        {
            car7.SetActive(true);
            car8.SetActive(true);
        }
        if (timer > 25)
        {
            car9.SetActive(true);
            car10.SetActive(true);
        }
        if (timer > 30)
        {
            car11.SetActive(true);
            car12.SetActive(true);
        }
        if (timer > 35)
        {
            car13.SetActive(true);
            car14.SetActive(true);
        }
        if (timer > 40)
        {
            car15.SetActive(true);
            car16.SetActive(true);
        }
    }

    public void SwitchCamera(int cameraId)
    {
        if (cameraId % 3 == 0)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
        }else if (cameraId % 3 == 1)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
        }else if (cameraId % 3 == 2)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
        }
    }
}
