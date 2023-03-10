using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //declaring variables
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashForce;
    [SerializeField] private float sideBoost; //amout of force added to jump when holding down left or right
    private bool onGround;
    private bool canDoubleJump;
    public float dashTimer;
    private Rigidbody2D playerRb;
    private Transform playerTrans;
    private BoxCollider2D playerBc;
    public bool movingLeft { get; private set; }
    public bool movingRight { get; private set; }

// Start is called before the first frame update
void Start()
    {
        //initializing private player variables
        playerRb = GetComponent<Rigidbody2D>();
        playerBc = GetComponent<BoxCollider2D>();
        playerTrans = GetComponent<Transform>();
        dashTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //moving left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0) //moving right
        {
            movingLeft = false;
            movingRight = true;

            //facing right
            playerTrans.localScale = new Vector3(Mathf.Abs(playerTrans.localScale.x), playerTrans.localScale.y, playerTrans.localScale.z);

            //moving based on position
            //playerTrans.position = new Vector3(playerTrans.position.x + speed * horizontalInput * Time.deltaTime, playerTrans.position.y, playerTrans.position.z);

            //moving based on force
            playerRb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);

            //moving based on velocity
            //playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
        }
        else if (horizontalInput < 0) //moving left
        {
            movingRight = false;
            movingLeft = true;

            //facing left
            playerTrans.localScale = new Vector3(-Mathf.Abs(playerTrans.localScale.x), playerTrans.localScale.y, playerTrans.localScale.z);

            //moving based on postion
            //playerTrans.position = new Vector3(playerTrans.position.x + speed * horizontalInput * Time.deltaTime, playerTrans.position.y, playerTrans.position.z);

            //moving based on force
            playerRb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);

            //moving based on velocity
            //playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);
        }
        else
        {
            movingRight = false;
            movingLeft = false;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {


        //side dash
        if (Input.GetKeyDown(KeyCode.Tab) && AbilityIsActive("Dash"))
        {
            Dash();
        }
    }

    private void Jump()
    {
        if (onGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                if (horizontalInput >= 0.01f)
                {
                    playerRb.AddForce(Vector2.right * sideBoost, ForceMode2D.Force);
                    print("right");
                }
                else if (horizontalInput <= -0.01f)
                {
                    playerRb.AddForce(Vector2.left * sideBoost, ForceMode2D.Force);
                    print("left");
                }
            }
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            playerRb.AddForce(Vector2.up * (jumpForce * .7f), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }


    private void Dash()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 && dashTimer <= 0)
        {
            playerRb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
        else if (horizontalInput < 0 && dashTimer <= 0)
        {
            playerRb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
        }
        dashTimer = 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    public bool AbilityIsActive(string name)
    {
        return false;
    }
}
