using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverUi : MonoBehaviour
{
    private Animator animator;
    private int startCount;
    public StarUi star1;
    public StarUi star2;
    public StarUi star3;
    public GameObject failPig;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Show(int startCount)//0 1 2 3
    {
        animator.SetTrigger("isShow");

        this.startCount = startCount;

    }
    private void Start()
    {
        // Debug.Log("GameUI");
        Show(1);
    }
    public void ShwoStar()
    {
        if (startCount==0)
        {
            failPig.gameObject.SetActive(true);
        }
        if (startCount>=1)
        {
            star1.Show();
        }
        if (startCount >=2)
        {
            star2.Show();
        }
        if (startCount>=3)
        {
            star3.Show();
        }
    }
}