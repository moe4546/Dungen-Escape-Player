using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Start()
    {
        base.Start();
        Health = base.health;
    }

    public override void Update()
    {
        SetCurrentAnimation();

        if (currentAnimation != "Idle")
        {
            Patrol();
        }
    }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }

}
