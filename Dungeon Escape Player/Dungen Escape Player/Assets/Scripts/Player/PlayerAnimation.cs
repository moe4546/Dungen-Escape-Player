using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Animator _swordAnimator;
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _swordRenderer;
    private Transform _swordTransform;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordAnimator = transform.GetChild(1).GetComponent<Animator>();
        _swordRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        _swordTransform = transform.GetChild(1).transform;
    }

    public void Run(float running)
    {
        _animator.SetFloat("running", Mathf.Abs(running));

        if(running < 0) 
        {
            _spriteRenderer.flipX = true;
            _swordRenderer.flipX = true;
            _swordRenderer.flipY = true;
            Vector3 newPos = _swordTransform.localPosition;
            newPos.x = -1.01f;
            _swordTransform.localPosition = newPos;
        }
        else if(running > 0) 
        {
            _spriteRenderer.flipX = false;
            _swordRenderer.flipX = false;
            _swordRenderer.flipY = false;
            Vector3 newPos = _swordTransform.localPosition;
            newPos.x = 1.01f;
            Debug.Log(newPos);
            _swordTransform.localPosition = newPos;
        }
    }

    public void Jump(bool jumping)
    {
        _animator.SetBool("jumping", jumping);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _swordAnimator.SetTrigger("SwordAnimation");
    }
}
