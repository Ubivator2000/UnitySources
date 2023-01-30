using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
    float distance = 20;
    public Transform pos;
    private Rigidbody rb;
    public string Name;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, distance) && Move.object_take == null)
        {
            Move.object_take = Name;
            rb.isKinematic = true;
            rb.MovePosition(pos.position);
        }
    }
    void FixedUpdate()
    {
        if (rb.isKinematic == true)
        {
            this.gameObject.transform.position = pos.position;
            if (Input.GetKey(KeyCode.E))
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.AddForce(Camera.main.transform.forward * 1);
                Move.object_take = null;
            }
        }
    }
}