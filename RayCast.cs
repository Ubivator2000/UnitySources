using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Transform Pointer;
    public Selectable CurrentSelectable;

    void LateUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward*100f, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable){
                if (CurrentSelectable && CurrentSelectable != selectable){
                    CurrentSelectable.Deselect();
                }
                CurrentSelectable = selectable;
                selectable.Select();
                if (Input.GetKey(KeyCode.G)){
                    selectable.Destroy();
                }
            }
            else{
                if (CurrentSelectable){
                    if (Input.GetKey(KeyCode.H)){
                    selectable.Instanse();
                    }
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
            }
        }
        else{
                if (CurrentSelectable){
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
            }
    }
}
