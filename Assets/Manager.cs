using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private List<Bird> birdList = new List<Bird>();// 小鸟列表
    private int currentIndex = -1; // 当前小鸟索引
    public int totalPigs; // 总猪数量
    public int deadPigs;//死亡数量
    private FollowTarget followTarget; //跟随目标
    //单例模式
    public static Manager Instance { get; private set; }
    private void Start()
    {
        Instance = this;
        birdList.AddRange(FindObjectsOfType<Bird>(false));
        totalPigs = FindObjectsOfType<Pig>(false).Length; // 获取场景中所有猪的数量
                                                          //Debug.Log(birdList.Count);
        followTarget = Camera.main.GetComponent<FollowTarget>();
        LoadNextBird();
      
    }

    public  void OnDeadPig()
    {
        deadPigs++;
        if (deadPigs>=totalPigs)
        {
            GameOver();
        }
    }

   private void GameOver()
    {
        Debug.Log("游戏结束");
    }
    public void LoadNextBird()
    {
        if (currentIndex >= birdList.Count -1)
        {
            GameOver();
           
            return;
        }
        else
        {
            currentIndex++;
            birdList[currentIndex].Gostage(SlingShot.Instance.GetCurrentPosition());
            followTarget.SetTarget(birdList[currentIndex].transform);
        }
       

    }
}
