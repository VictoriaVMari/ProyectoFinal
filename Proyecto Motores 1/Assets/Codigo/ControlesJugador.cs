using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ControlesJugador : MonoBehaviour
{

    private Rigidbody rb; 

    private float movementX;
    private float movementY; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();  

    }

    void OnMove(InputValue MovementValue)
    {
        Vector2 movementVector = MovementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y; 

    }

    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement); 
    }
}
