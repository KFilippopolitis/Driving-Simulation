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
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    private int counter = 0;

    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera(counter);
            counter++;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1.5f;
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            Time.timeScale = 0.5f;
        }
        timer = Time.deltaTime + timer;
        if (timer > 5)
        {
            car1.SetActive(true);
            car2.SetActive(true);
            car3.SetActive(true);
            car4.SetActive(true);
        }
        if (timer > 10)
        {
            car5.SetActive(true);
            car6.SetActive(true);
            car7.SetActive(true);
            car8.SetActive(true);
        }
        if (timer > 20)
        {
            car9.SetActive(true);
            car10.SetActive(true);
            car11.SetActive(true);
            car12.SetActive(true);
        }
        if (timer > 30)
        {
            car13.SetActive(true);
            car14.SetActive(true);
            car15.SetActive(true);
            car16.SetActive(true);
        }
    }
    public void SwitchCamera(int counter)
    {
        if (counter % 4 == 0)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }else if (counter % 4 == 1)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }else if (counter % 4 == 2)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
        }else if (counter % 4 == 3)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
        }
    }
}
