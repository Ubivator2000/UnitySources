using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    float distance = 20;
    public Transform pos;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance))
        {
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }
    }
    void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 500);
            }
        }
    }
}
