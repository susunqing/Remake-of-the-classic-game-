using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    // 单例实例
    public static SlingShot Instance { get; private set; }

    public Transform SlingShotLiftPosition;   // 左锚点
    public Transform SlingShotRightPosition;  // 右锚点
    public Transform SlingShotMiddlePosition;  // 中心点（拉伸点）

    private LineRenderer LiftLineRenderer;// 右侧绳索渲染器
    private LineRenderer RightLineRenderer;//左侧绳索渲染器

    private Transform birdTranform; //小鸟的Transfor
    private bool isStartDraw = false;//是否开始绘制

    void Awake()
    {

        Instance = this;

        RightLineRenderer = GameObject.Find("RightLineRenderer").GetComponent<LineRenderer>();
        Debug.Log(RightLineRenderer+"111");
        LiftLineRenderer = GameObject.Find("LiftLineRenderer").GetComponent<LineRenderer>();


        SlingShotLiftPosition = transform.Find("SlingShotLiftPosition");
        SlingShotRightPosition = transform.Find("SlingShotRightPosition");
        SlingShotMiddlePosition = transform.Find("SlingShotMiddlePosition");


    }


    private void Start()
    {
        HideLine();
    }
    // Update is called once per frame
    void Update()
    {
        if (isStartDraw)
        {
            Draw();
        }
    }

    public void StartDraw(Transform birdTransform)
    {
        isStartDraw = true;
        this.birdTranform = birdTransform;
        ShowLine();
    }

    private void Draw()
    {
        Vector3 birdPosition = birdTranform.position;

        //计算拉伸点位置
       birdPosition= (birdTranform.position - SlingShotMiddlePosition.position).normalized * 0.4f + birdTranform.position;

        //绘制左侧绳索
        LiftLineRenderer.SetPosition(0, birdPosition);
        LiftLineRenderer.SetPosition(1, SlingShotLiftPosition.position);

        //绘制右侧绳索
        RightLineRenderer.SetPosition(0, birdPosition);
        RightLineRenderer.SetPosition(1, SlingShotRightPosition.position);
    }

    public void EndDraw()
    {
        isStartDraw = false;
        HideLine();
    }
    public Vector3 GetCurrentPosition()
    {
        return SlingShotMiddlePosition.transform.position;
    }

    private void ShowLine()
    {
        RightLineRenderer.enabled = true;
        LiftLineRenderer.enabled = true;
    }

    private void HideLine()
    {
        RightLineRenderer.enabled = false;
        LiftLineRenderer.enabled = false;
    }
}
