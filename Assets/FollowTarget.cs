using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform target;

    private float smoothSpeed = 5f; // ƽ��������ٶ�
    private void Update()
    {
        if (target != null)
        {
            //�ȵõ��Լ���λ�ã��ڰ�Ŀ��λ�ø�ֵ���Լ���λ��
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
