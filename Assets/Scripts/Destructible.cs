using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maxHp = 100; // 最大生命值
    private int currentHp = 0;

    public List<Sprite> injureSpriteList; // 受伤时的精灵列表
   public SpriteRenderer spriteRenderer; // 用于显示受伤状态的精灵渲染器
    private GameObject prefabBoom;// 爆炸动画
    //public static Destructible Instance {  get; private set; }
    private void Awake()
    {
       // Instance = this;
    }
    private void Start()
    {
        currentHp = maxHp;
        spriteRenderer= GetComponent<SpriteRenderer>();
        prefabBoom=Resources.Load<GameObject>("Boom1");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Hurt(currentHp -= (int)collision.relativeVelocity.magnitude * 8);
    }
    public  void  Hurt(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            Dead();
        }
        else
        {
            int index = ((int)(maxHp - currentHp) / (maxHp / (injureSpriteList.Count )))-1;
           // Debug.Log(index+"index");
            if (index != -1)
            {
                //Debug.Log(index + "if");
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
