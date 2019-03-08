using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skelton : Enemy, IDamageable
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

        if (currentAnimation != "Idle" && isHit == false)
        {
            Patrol();
        }
    }

    public void Damage()
    {
        Health -= 1;
        isHit = true;

        if(Health < 1)
        {
            Destroy(gameObject);
        }
        else 
        {
            animator.SetTrigger("Hit");
        }
    }
}
