using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlesJugador : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la esfera
    public float jumpForce = 10f; // Fuerza del salto
    private bool isGrounded; // Variable para controlar si la esfera está en el suelo

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Verifica si la esfera ha colisionado con el suelo
        if (other.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
        }
    }
}