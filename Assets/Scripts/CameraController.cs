using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float verticalInputValue;
    private float horizontalInputValue;
    private float zoomInputValue;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInputValue = Input.GetAxis("Vertical");
        horizontalInputValue = Input.GetAxis("Horizontal");
        zoomInputValue = Input.GetAxis("Mouse ScrollWheel");
    }
    private void move()
    {
        Vector3 movementVertical = transform.forward *50 * Time.deltaTime * verticalInputValue;
        Vector3 zoomInAndOut = transform.up * 80 * Time.deltaTime * zoomInputValue ;
        rigidBody.MovePosition(rigidBody.position + movementVertical+zoomInAndOut);
    }
    private void FixedUpdate()
    {
        move();
        turn();
    }
    private void turn()
    {
        float turn = 90 * Time.deltaTime * horizontalInputValue;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rigidBody.MoveRotation(rigidBody.rotation * turnRotation);

    }

}
