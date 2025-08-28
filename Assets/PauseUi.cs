using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUi : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPauseButtonClick()
    {
        animator.SetBool("isShow",true);
        Time.timeScale = 0;
    }
    public void OnReStartButtonClick()
    {

    }
    public void OnBackButtonClick()
    {
        animator.SetBool("isShow",false);
        Time.timeScale = 1;
        
    }
    public void OnMenuButtonClick()
    {
        
    }



}
