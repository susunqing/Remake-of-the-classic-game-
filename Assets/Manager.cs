using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private List<Bird> birdList = new List<Bird>();// С���б�
    private int currentIndex = -1; // ��ǰС������
    public int totalPigs; // ��������
    public int deadPigs;//��������
    private FollowTarget followTarget; //����Ŀ��
    //����ģʽ
    public static Manager Instance { get; private set; }
    private void Start()
    {
        Instance = this;
        birdList.AddRange(FindObjectsOfType<Bird>(false));
        totalPigs = FindObjectsOfType<Pig>(false).Length; // ��ȡ�����������������
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
        Debug.Log("��Ϸ����");
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
