using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour
{
    //GameObject.Find("Quest").GetComponent<Quest1>().usage

    public float Speed = 12f;                 // How fast the car moves forward and back.
    public float TurnSpeed = 180f;            // How fast the car turns in degrees per second.

    private float MovementInputValue;         
    private float TurnInputValue;
    private Rigidbody Rigidbody;              // Reference used to move the car.

   

    private void Start()
    {
        
        Rigidbody = GetComponent<Rigidbody>();
       
    }

    

    private void Update()
    {
        
            // Store the value of both input axes.
            MovementInputValue = Input.GetAxis("Vertical");
            TurnInputValue = Input.GetAxis("Horizontal");
        
        
    }

    private void FixedUpdate()
    {
            // Adjust the rigidbodies position and orientation in FixedUpdate.
            Move();
            Turn();
        
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

}
