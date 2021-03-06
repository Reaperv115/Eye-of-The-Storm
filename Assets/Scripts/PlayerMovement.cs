﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    float speed = 12f;
    float gravity = -9.81f;

    [SerializeField]
    Transform groundCheck;
    float groundDist = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundmask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    //working on slowing player when walking through melted floor
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.name == "lava puddle(Clone)")
        {
            speed = 9.0f;
        }
    }
}
