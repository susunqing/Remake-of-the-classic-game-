using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBird :Bird
{
    private float boomRadius = 2f;
    protected override void FullSkill()
    {
      
       Collider2D[] results = Physics2D.OverlapCircleAll(this.transform.position, boomRadius);
        foreach (Collider2D item in results)
        {
          Destructible des= item.GetComponent<Destructible>();
            des?.Hurt(1000);
        }
        
        biredState = BiredState.WitDead;
        ToDead();
    }
}
