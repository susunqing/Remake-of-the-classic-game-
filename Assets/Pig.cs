using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructible
{
    // Start is called before the first frame update

    public override void Dead()
    {
        base.Dead();
        Manager.Instance.OnDeadPig();
      //  Debug.Log("Pig.Dead() ±»µ÷ÓÃ");
        ScoreManager.Instance.ShowScore(transform.position, 3000);
        



    }
}
