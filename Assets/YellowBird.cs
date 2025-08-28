using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Bird
{
    protected override void FlyingSkill()
    {
        rig.velocity=rig.velocity * 2;
    }
    protected override void FullSkill()
    {
        
    }
}
