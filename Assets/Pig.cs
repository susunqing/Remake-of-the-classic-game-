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
      //  Debug.Log("Pig.Dead() 被调用");
        ScoreManager.Instance.ShowScore(transform.position, 3000);
        AudioManager.Instance.PigCollisionDelegate(this.transform.position);



    }
}
