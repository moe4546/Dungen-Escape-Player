using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    public GameObject acid;
    public float acidSpeed;

    public override void Start()
    {
        base.Start();
        Health = base.health;
    }

    public override void Update()
    {
        SetCurrentAnimation();

        //if (currentAnimation != "Idle")
        //{
        //    Patrol();
        //}
    }

    public void Damage()
    {
        Health -= 1;
        inCombat = true;
        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(gameObject);
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    public void Attack()
    {
        GameObject acidInst = Instantiate(acid, transform.position, Quaternion.identity) as GameObject;

        if(spriteRenderer.flipX == false)
        {
            // Move right
            acidInst.GetComponent<Rigidbody2D>().velocity = new Vector2(acidSpeed * Time.deltaTime, 0);
        }
        else 
        {
            // Move left
            acidInst.GetComponent<Rigidbody2D>().velocity = new Vector2(-acidSpeed * Time.deltaTime, 0);
        }
    }

}
