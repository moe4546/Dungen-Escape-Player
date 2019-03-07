using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;
    protected Transform lastPos;
    protected Animator animator;
    protected string currentAnimation;
    protected SpriteRenderer spriteRenderer;

    public virtual void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        transform.position = pointA.position;
        lastPos = pointA;
    }

    protected void Patrol()
    {
        // Move
        if (lastPos == pointA)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }
        else if (lastPos == pointB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }

        // Reach Point?
        if (transform.position.x >= pointB.position.x)
        {
            lastPos = pointB;
            animator.Play("Idle");
            //spriteRenderer.flipX = true;
        }
        else if (transform.position.x <= pointA.position.x)
        {
            lastPos = pointA;
            animator.Play("Idle");
            //spriteRenderer.flipX = false;
        }
    }

    protected void SetCurrentAnimation()
    {
        AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
        currentAnimation = clipInfos[0].clip.name;
    }

    public virtual void Attack()
    {

    }

    public abstract void Update();

}
