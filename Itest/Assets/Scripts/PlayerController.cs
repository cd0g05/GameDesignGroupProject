using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    [SerializeField] private float speed = 8.0f;
    public bool isInAir = false;
    // private int health = 5;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] public LayerMask ground;
    private int playerSize = 15;
    // When game is starting up
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime != 0)
        {
            Movement();

        }
    }

    void Movement() 
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-playerSize, playerSize);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(playerSize, playerSize);

        }
        else if (Input.GetButtonUp("Horizontal") && isInAir == false)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();

        }
        if (coll.IsTouchingLayers(ground) && isInAir == true)
        {
            isInAir = false;
        }
       
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isInAir = true;
    }
}
