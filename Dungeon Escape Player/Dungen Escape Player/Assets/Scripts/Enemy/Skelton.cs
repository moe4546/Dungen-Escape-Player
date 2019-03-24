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
        CheckCombat();

        if (currentAnimation != "Idle" && inCombat == false)
        {
            Patrol();
        }

        if(inCombat)
        {
            LookAtPlayer();
        }
    }

    public void Damage()
    {
        Health -= 1;
        inCombat = true;
        animator.SetBool("InCombat", true);

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
