using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Min(1f)]
    float movementSpeed = 2f;

    Vector2 moveInput;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerUpdate()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.x = Input.GetAxis("Horizontal");
    }

    public void PlayerPhysicsUpdate()
    {
        rb.velocity = new Vector3(moveInput.x * movementSpeed, 0, moveInput.y * movementSpeed);
    }
}
