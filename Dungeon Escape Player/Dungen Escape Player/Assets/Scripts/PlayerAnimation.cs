using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprteRenderer;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _sprteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Run(float running)
    {
        _animator.SetFloat("running", Mathf.Abs(running));

        if(running < 0) 
        {
            _sprteRenderer.flipX = true;
        }
        else if(running > 0) 
        {
            _sprteRenderer.flipX = false;
        }
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("jumping", jumping);
    }
}
