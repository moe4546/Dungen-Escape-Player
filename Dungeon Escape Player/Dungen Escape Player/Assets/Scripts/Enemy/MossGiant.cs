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

    void Patrol()
    {
        // Move
        if (lastPos == pointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        }
        else if (lastPos == pointB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }

        // Reach Point?
        if(transform.position.x >= pointB.position.x)
        {
            lastPos = pointB;
            animator.Play("Idle");
            spriteRenderer.flipX = true;
        }
        else if(transform.position.x <= pointA.position.x)
        {
            lastPos = pointA;
            animator.Play("Idle");
            spriteRenderer.flipX = false;
        }
    }

    private void SetCurrentAnimation()
    {
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
        currentAnimation = clipInfos[0].clip.name;
    }
}
