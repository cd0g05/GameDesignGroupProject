using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //declaring variables
    [SerializeField] private float speed;
    public float dashForce;
    [SerializeField] private float sideBoost; //amout of force added to jump when holding down left or right
    [SerializeField] private Vector2 maxVelocity;
    [SerializeField] private float slowDown;
    [SerializeField] private Vector3 lastFramePos;
    public float dashing;
    public bool jumped;
    private int count; //for position update
    public bool canDoubleJump;
    public float jumpForce;
    public float dashTimer;
    private Rigidbody2D playerRb;
    private Transform playerTrans;
    private CapsuleCollider2D playerBc;
    public bool onSlope;
    public bool onGround;
    public bool movingLeft { get; private set; }
    public bool movingRight { get; private set; }
    public InventoryObject Inventory;

// Start is called before the first frame update
void Start()
    {
        //initializing private player variables
        playerRb = GetComponent<Rigidbody2D>();
        playerBc = GetComponent<CapsuleCollider2D>();
        playerTrans = GetComponent<Transform>();
        dashTimer = 5;
        lastFramePos = transform.position;
        Physics2D.IgnoreLayerCollision(3, 7, false);
        GameObject.Find("HealthController").GetComponent<HealthController>().canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        //seeing if on ground
        /*RaycastHit2D[] boxes = Physics2D.BoxCastAll(playerBc.bounds.center, playerBc.bounds.size, 0, Vector2.down, 0.01f);
        foreach (RaycastHit2D hitObject in boxes)
        {
            if (hitObject && (hitObject.collider.gameObject.CompareTag("Ground")))
            {
                onGround = true;
                onSlope = false;
                break;
            }
            else if (hitObject && (hitObject.collider.gameObject.CompareTag("Slope")))
            {
                onSlope = true;
                onGround = false;
                break;
            }
            else
            {
                onGround = false;
                onSlope = false;
            }
        }*/


        if (onGround || onSlope)
        {
            playerRb.drag = 5;
            maxVelocity.x = 7;
        }
        else
        {
            playerRb.drag = 0;
            maxVelocity.x = 5;
        }

        if (jumped && playerRb.velocity.y <= 0)
        {
            playerRb.gravityScale = 2;
        }


        //print(playerRb.velocity);
        //moving left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0) //moving right
        {
            //facing right
            playerTrans.localScale = new Vector3(Mathf.Abs(playerTrans.localScale.x), playerTrans.localScale.y, playerTrans.localScale.z);

            //moving based on velocity
            //if they are on ground
            if (onGround)
            {
                if (playerRb.velocity.x < maxVelocity.x)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed), playerRb.velocity.y);
                }
                else
                {
                    playerRb.velocity = new Vector2(maxVelocity.x, playerRb.velocity.y);
                }
            }

            //if they are in the air velocity is slowed down
            else if (!onGround && !onSlope)
            {
                // if they are trying to switch directions
                if (Mathf.Sign(playerRb.velocity.x) != Mathf.Sign(horizontalInput))
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * 0.5f), playerRb.velocity.y);
                }

                else if (playerRb.velocity.x < maxVelocity.x - 0.5f)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .75f), playerRb.velocity.y);
                }
                else
                {
                    playerRb.velocity = new Vector2(maxVelocity.x - 0.5f, playerRb.velocity.y);
                }
            }

            //player is on a slope
            else if (onSlope)
            {
                //if player is going up, speed is slower
                if (transform.position.y > lastFramePos.y)
                {
                    if (playerRb.velocity.x < maxVelocity.x - 2.5f)
                    {
                        playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .05f), playerRb.velocity.y);
                    }

                    else
                    {
                        playerRb.velocity = new Vector2(maxVelocity.x - 2.5f, playerRb.velocity.y);
                    }
                }

                //player is going down, speed is faster
                else if (transform.position.y < lastFramePos.y)
                {
                    if (playerRb.velocity.x < maxVelocity.x + 1.5f)
                    {
                        playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .05f), playerRb.velocity.y);
                    }
                    else
                    {
                        playerRb.velocity = playerRb.velocity;
                    }
                }
            }

            movingLeft = false;
            movingRight = true;
        }
        else if (horizontalInput < 0) //moving left
        {
            //facing left
            playerTrans.localScale = new Vector3(-Mathf.Abs(playerTrans.localScale.x), playerTrans.localScale.y, playerTrans.localScale.z);

            //moving based on velocity
            if (onGround)
            {
                if (playerRb.velocity.x > -maxVelocity.x)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed), playerRb.velocity.y);
                }
                else
                {
                    playerRb.velocity = new Vector2(-maxVelocity.x, playerRb.velocity.y);
                }
            }

            //if player is in air, speed is slowed
            else if (!onSlope && !onGround)
            {
                // if they are trying to switch directions
                if (Mathf.Sign(playerRb.velocity.x) != Mathf.Sign(horizontalInput))
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * 0.5f), playerRb.velocity.y);
                }

                else if (playerRb.velocity.x > -maxVelocity.x + 0.5f)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .75f), playerRb.velocity.y);
                }
                else
                {
                    playerRb.velocity = new Vector2(-maxVelocity.x + 0.5f, playerRb.velocity.y);
                }
            }

            //player is on a slope
            else if (onSlope)
            {
                //if player is going up, speed is slower
                if (transform.position.y > lastFramePos.y)
                {
                    if (playerRb.velocity.x > -maxVelocity.x + 2.5f)
                    {
                        playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .05f), playerRb.velocity.y);
                    }
                    else
                    {
                        playerRb.velocity = new Vector2(-maxVelocity.x + 2.5f, playerRb.velocity.y);
                    }
                }

                //player is going down, speed is faster
                else if (transform.position.y < lastFramePos.y)
                {
                    if (playerRb.velocity.x > -maxVelocity.x - 1.5f)
                    {
                        playerRb.velocity = new Vector2(playerRb.velocity.x + (horizontalInput * speed * .05f), playerRb.velocity.y);
                    }
                    else
                    {
                        playerRb.velocity = playerRb.velocity;
                    }
                }
            }



            movingRight = false;
            movingLeft = true;
        }
        else
        {
            movingRight = false;
            movingLeft = false;

            //slows player down if not pressing any key
            if (Mathf.Abs(playerRb.velocity.x) > 0)
            {
                if (onSlope || onGround)
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x / 1.05f, playerRb.velocity.y);
                }

                else
                {
                    playerRb.velocity = new Vector2(playerRb.velocity.x / 1.01f, playerRb.velocity.y);
                }
            }
        }

        if (playerRb.velocity.y < -maxVelocity.y)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -maxVelocity.y);
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

        if (count % 5 == 0)
        {
            lastFramePos = transform.position;
        }
        count++;
    }


    private void Jump()
    {
        if (onGround || onSlope)
        {
            jumped = true;
            playerRb.gravityScale = 1.5f;
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
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            jumped = false;
            playerRb.gravityScale = 1.5f;
        }
        if (collision.gameObject.CompareTag("Slope"))
        {
            onSlope = true;
            jumped = false;
            playerRb.gravityScale = 1.5f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
        if (collision.gameObject.CompareTag("Slope"))
        {
            onSlope = false;
        }
    }

    public bool AbilityIsActive(string name)
    {
        return false;
    }
    
}
