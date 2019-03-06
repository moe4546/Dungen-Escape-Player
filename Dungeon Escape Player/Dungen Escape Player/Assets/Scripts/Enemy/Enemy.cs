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

    public virtual void Attack()
    {

    }

    public abstract void Update();

}
