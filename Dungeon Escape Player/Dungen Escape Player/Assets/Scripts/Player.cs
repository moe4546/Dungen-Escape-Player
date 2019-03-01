using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rayLength = 2f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D _rigid;
    
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = _rigid.velocity.y;

        if (Input.GetKeyDown("space") && isGroundend())
        {
            verticalInput = jumpForce;
        }

        _rigid.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput);
    }

    public bool isGroundend()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayer);
        
        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
