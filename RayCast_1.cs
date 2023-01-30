using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{   
    public GameObject Cube_obj;
    public Transform Target;
    int layerMask = 1<<2;   

    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward*100f, Color.yellow);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3, layerMask) && Move.object_take == "Cube") {
            Debug.Log("Hit Mask");
            if (Input.GetKey(KeyCode.F)){
                Cube_obj.GetComponent<Rigidbody>().isKinematic = true;
                Cube_obj.GetComponent<Rigidbody>().MovePosition(Target.position);
            }
        }
        else{
            Debug.Log("Dont Hit Mask");
        }
    }
}