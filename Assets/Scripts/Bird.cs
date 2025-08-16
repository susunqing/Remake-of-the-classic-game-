using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public enum BiredState
{
    Witting,
    BeforeShout,
    AfterShout
}
public class Bird : MonoBehaviour
{
    public BiredState biredState = BiredState.Witting;
    //三种状态
    //等待 发射前 发射后

    //最大活动范围半径
    private float maxDistance = 2.5f;

    //鼠标状态
    public bool isMouseDown;

    private void Update()
    {
        switch (biredState)
        {
            case BiredState.Witting:
                break;
            case BiredState.BeforeShout:
                MoveCollider();
                break;
            case BiredState.AfterShout:
                break;
            default:
                break;
        }

        //Debug.Log(Input.mousePosition);
    }


    private void OnMouseDown()
    {

       
        if (biredState==BiredState.BeforeShout)
        {
            isMouseDown = true;
            SlingShot.Instance.StartDraw(transform);
        }
    }
    
    private void OnMouseUp() 
    {
        if (biredState == BiredState.BeforeShout)
        {
            isMouseDown = false;
            SlingShot.Instance.EndDraw();
        }
    }

    private void MoveCollider()
    {
        if (isMouseDown) 
        {
            this.gameObject.transform.position = GetMousePosition();
        }
    }
    private Vector3 GetMousePosition()
    {
        //获取限制范围中心点
        Vector3 centerPosition = SlingShot.Instance.GetSetPosition();
        //获取鼠标位置并转换为世界坐标
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        //鼠标位置与中心点的距离
        Vector3 vector3 = mousePosition-centerPosition;
        if (vector3.magnitude > maxDistance)
        {
           mousePosition= vector3.normalized*maxDistance + centerPosition;
        }


        
        return mousePosition;
    }
}
