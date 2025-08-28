using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUi : MonoBehaviour
{
    private Animator animator;
    public GameObject startF;
    public GameObject startBg;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        animator.SetTrigger("isShow");
        startBg.SetActive(true);
        startF.SetActive(true);
        Debug.Log("Show");
    }
}
