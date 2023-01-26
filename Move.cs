using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public float speed = 10f;
    public float gravity = -9.8f;
    public float GroundDistance = 0.5f;
    public float jump = 1.5f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool Ground;

    void Update()
    {
        Ground = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        if (Ground && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Ground) {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        if (Input.GetKey("c") && Ground){
            controller.height = 1f;
        }

        else {
            controller.height = 2f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && Ground){
            speed = 20f;
        }

        else{
            speed = 10f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}