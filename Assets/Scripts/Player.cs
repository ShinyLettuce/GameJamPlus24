using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Min(1f)]
    float movementSpeed = 2f;

    [SerializeField]
    GameObject waterSign, scriptSign;

    Vector2 moveInput;

    Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void PlayerUpdate()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.x = Input.GetAxis("Horizontal");

        if(moveInput.magnitude > 0f)
        {
            animator.SetBool("IsWalking", true);
            Debug.Log("wLAKIN");
        }
        else
        {
            animator.SetBool("IsWalking", false);
            Debug.Log("NOT wLAKIN");
        }
    }

    public void PlayerPhysicsUpdate()
    {
        rb.velocity = new Vector3(moveInput.x * movementSpeed, 0, moveInput.y * movementSpeed);
    }

    public void PlayerRender(bool hasWater, bool hasScript)
    {
        waterSign.SetActive(hasWater);
        scriptSign.SetActive(hasScript);
    }
}
