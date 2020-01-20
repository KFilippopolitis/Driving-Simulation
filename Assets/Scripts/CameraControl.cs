using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float verticalInputValue;
    private float horizontalInputValue;
    private float zoomInputValue;
    private Rigidbody Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        verticalInputValue = Input.GetAxis("Vertical");
        horizontalInputValue = Input.GetAxis("Horizontal");
        zoomInputValue = Input.GetAxis("Mouse ScrollWheel");
    }
    private void Move()
    {
        Vector3 movementVertical = transform.forward *50 * Time.deltaTime * verticalInputValue;
        Vector3 zoomInAndOut = transform.up * 80 * Time.deltaTime * zoomInputValue ;
        Rigidbody.MovePosition(Rigidbody.position + movementVertical+zoomInAndOut);
    }
    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    private void Turn()
    {
        float turn = 90 * Time.deltaTime * horizontalInputValue;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);

    }

}
