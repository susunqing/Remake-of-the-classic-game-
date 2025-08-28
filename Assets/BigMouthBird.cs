using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouthBird : Bird
{
    protected override void FlyingSkill()
    {
        Vector2 vector2 = rig.velocity;
        vector2.x  = -rig.velocity.x;
        rig.velocity = vector2;

        Vector3 scale = this.transform.localScale;
        scale.x = -scale.x;
        this.transform.localScale = scale;

    }
    protected override void FullSkill()
    {
       
    }
}
