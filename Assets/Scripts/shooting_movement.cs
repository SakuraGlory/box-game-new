using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_movement : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    Vector3 dragStartPos;
    Touch touch;
    void Update() {
        if(Input.touchCount >0){
          touch = Input.GetTouch(0);

          if (touch.phase == TouchPhase.Began){
              DragStart();
          }
          if (touch.phase == TouchPhase.Moved)
          {
              Dragging();
          }
          if (touch.phase == TouchPhase.Ended){
              DragRelese();
          }
        }
    }
    void DragStart(){
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }
    void Dragging(){
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1,draggingPos);
    }
    void DragRelese(){
        lr.positionCount = 0;
        Vector3 dragRelesePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragRelesePos.z = 0f;
        Vector3 force = dragStartPos - dragRelesePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force,maxDrag)* power;
        rb.AddForce(clampedForce,ForceMode2D.Impulse);
    }
}