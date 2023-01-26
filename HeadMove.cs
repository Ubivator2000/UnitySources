using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeadMove : MonoBehaviour
{
public Transform player;

    public float mouseSens = 100f;

    float xRotation = 0f;

    void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -65f, 65f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * MouseX);
    }
}