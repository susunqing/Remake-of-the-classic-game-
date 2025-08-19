using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;

    private float smoothSpeed = 5f; // 平滑跟随的速度
    private void Update()
    {
        if (target != null)
        {
            //先得到自己的位置，在把目标位置赋值给自己的位置
            Vector3 position = transform.position;
            position.x = target.transform.position.x;
            position.x = math.clamp(position.x,1,19);
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothSpeed);
           
        }
        else
        {
            Debug.LogWarning("Target is not set for FollowTarget script.");
        }
    }
    public void SetTarget(Transform pos)
    {
        this.target = pos;
    }


}
