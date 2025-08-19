using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public enum BiredState
{
    Witting,
    BeforeShout,
    AfterShout,
    WitDead
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
    //飞行速度
    public float flySpeed = 10f;

    private Rigidbody2D rig;
    #region Unity 消息

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.bodyType = RigidbodyType2D.Static;
    }
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
                StopContorl();
                break;
            case BiredState.WitDead:
                break;
            default:
                break;
        }

        //Debug.Log(Input.mousePosition);
    }


    private void OnMouseDown()
    {

        biredState = BiredState.BeforeShout;
        if (biredState == BiredState.BeforeShout)
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
            Fly();
            biredState = BiredState.AfterShout;
        }
    }

    #endregion


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
        Vector3 centerPosition = SlingShot.Instance.GetCurrentPosition();
        //获取鼠标位置并转换为世界坐标
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        //鼠标位置与中心点的距离
        Vector3 vector3 = mousePosition - centerPosition;
        if (vector3.magnitude > maxDistance)
        {
            mousePosition = vector3.normalized * maxDistance + centerPosition;
        }

        return mousePosition;
    }

    private void Fly()
    {//刚体设置动态 设置速度
        rig.bodyType = RigidbodyType2D.Dynamic;
        rig.velocity = (SlingShot.Instance.GetCurrentPosition() - transform.position).normalized * flySpeed;
    }
    //上场方法
    public void Gostage(Vector3 position)
    {
        //biredState = BiredState.BeforeShout;
        transform.position = position;
    }
    private void StopContorl() 
    {
        
        if (rig.velocity.magnitude<1f)
        {
            Invoke("ToDead", 1f);
            biredState = BiredState.WitDead;
            //Debug.Log("销毁111");
        }
        
    }

    private void ToDead()
    {
        Destroy(gameObject);
        GameObject.Instantiate(Resources.Load("Boom1"),transform.position,Quaternion.identity);
        Manager.Instance.LoadNextBird();
    }

}
