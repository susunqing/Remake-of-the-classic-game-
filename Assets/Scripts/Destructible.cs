using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maxHp = 100; // �������ֵ
    private int currentHp = 0;

    public List<Sprite> injureSpriteList; // ����ʱ�ľ����б�
   public SpriteRenderer spriteRenderer; // ������ʾ����״̬�ľ�����Ⱦ��
    private GameObject prefabBoom;// ��ը����
    private void Start()
    {
        currentHp = maxHp;
        spriteRenderer= GetComponent<SpriteRenderer>();
        prefabBoom=Resources.Load<GameObject>("Boom1");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        currentHp -= (int)collision.relativeVelocity.magnitude * 8;

        if (currentHp < 0)
        {
            Dead();
        }
        else
        {
            int index = ((int)(maxHp - currentHp) / (maxHp / (injureSpriteList.Count + 1))) - 1;
            if (index!=-1)
            {
                spriteRenderer.sprite = injureSpriteList[index];
            }
                
        }
    }
    
    public virtual void Dead()
    {
        Destroy(gameObject);
        GameObject boom = Instantiate(prefabBoom, transform.position, Quaternion.identity);
    }
    void Update()
    {

    }
}
