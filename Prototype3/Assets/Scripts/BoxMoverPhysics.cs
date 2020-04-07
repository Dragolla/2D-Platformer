using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMoverPhysics : MonoBehaviour
{
    private Vector3 MouseOffset;


    private void OnMouseDown()
    {

        MouseOffset = gameObject.transform.position - GetMousePos();

    }
    private Vector3 GetMousePos()
    {
        Vector3 Mousecoords = Input.mousePosition;

        return Camera.main.ScreenToWorldPoint(Mousecoords);

    }
    private void OnMouseDrag()
    {
        this.transform.position = GetMousePos() + MouseOffset;
    }

}
   
    
