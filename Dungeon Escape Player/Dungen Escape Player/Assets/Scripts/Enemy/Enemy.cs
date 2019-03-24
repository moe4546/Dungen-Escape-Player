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
    protected bool inCombat;
    protected GameObject player;
    protected float direction;

    public virtual void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        transform.position = pointA.position;
        lastPos = pointA;
        player = FindObjectOfType<Player>().gameObject;
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

    public abstract void Update();

    protected void CheckCombat()
    {
        float distance = Vector2.Distance(transform.position, player.gameObject.transform.position);
        if(distance < 2)
        {
            inCombat = true;
            animator.SetTrigger("Idle");
            animator.SetBool("InCombat", true);
        }
        else 
        {
            inCombat = false;
            animator.SetBool("InCombat", false);
        }
    }

    protected void LookAtPlayer()
    {
        Vector2 dist = player.gameObject.transform.localPosition - transform.localPosition;
        direction = dist.x;
        Debug.Log(direction);
        if(direction < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(direction > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

}
