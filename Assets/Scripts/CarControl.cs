using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarControl : MonoBehaviour
{
    public GameObject Speedtext;
    public GameObject text;
    Text spText;
    public float Speed = 12f;                 // How fast the car moves forward and back.
    public float TurnSpeed = 180f;            // How fast the car turns in degrees per second.
    public float MovementInputValue;         
    public float TurnInputValue;
    private Rigidbody Rigidbody;
    public GameObject rightAlarm;
    public GameObject leftAlarm;
    public GameObject rightAlarmBack;
    public GameObject leftAlarmBack;
    public int rng=3;
    public bool leftAlarmEnabled = false;
    public bool rightAlarmEnabled = false;
    public int checkMovement = 0;
    AlarmHandler alarmHandler;
    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        MovementInputValue = Input.GetAxis("Vertical");
        TurnInputValue = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.U))
        {
            Speed += 5;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Speed -= 5;
        }
        if (MovementInputValue != 0 || TurnInputValue != 0)
        {
            checkMovement++;
        }
        if (Input.GetKeyDown(KeyCode.E)&&leftAlarmEnabled==false)
        {
            TurnOffOrOn(rightAlarm);
            TurnOffOrOn(rightAlarmBack);
            rightAlarmEnabled = !rightAlarmEnabled;
            rng = 1;
        }
        if (Input.GetKeyDown(KeyCode.Q)&&rightAlarmEnabled == false)
        {
            TurnOffOrOn(leftAlarm);
            TurnOffOrOn(leftAlarmBack);
            leftAlarmEnabled = !leftAlarmEnabled;
            rng = 2;
        }


    }

    public void TurnOffOrOn(GameObject g)
    {
        alarmHandler = g.GetComponent<AlarmHandler>();
        if (alarmHandler.enabled == true)
        {
            Light l;
            l = g.GetComponent<Light>();
            l.enabled = false;
        }
        alarmHandler.enabled = !alarmHandler.enabled;
    }
    
    private void FixedUpdate()
    {
        // Adjust the rigidbodies position and orientation in FixedUpdate.
        Move();
        Turn();
        spText = Speedtext.GetComponent<Text>();
        spText.text = (Speed*MovementInputValue).ToString();    
    }




    private void Move()
    {
        
            // Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
            Vector3 movement = transform.forward * Speed * Time.deltaTime * MovementInputValue;

            // Apply this movement to the rigidbody's position.
            Rigidbody.MovePosition(Rigidbody.position + movement);
            
    }


    private void Turn()
    {
            // Determine the number of degrees to be turned based on the input, speed and time between frames.
            float turn = TurnSpeed * Time.deltaTime * TurnInputValue;

            // Make this into a rotation in the y axis.
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

            // Apply this rotation to the rigidbody's rotation.
            Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
        
    }
    public void ChangeText(string s)
    {
        Text textemp;
        textemp = text.GetComponent<Text>();
        textemp.text = s;
    }

}
