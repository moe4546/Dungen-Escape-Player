using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        SetCurrentAnimation();

        if (currentAnimation != "Idle")
        {
            Patrol();
        }
    }

}
