using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private PlayerMovement playerMoveScript;
    private Rigidbody2D playerRb;
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        jumpForce = playerMoveScript.jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Use();
        }
    }

    public void Use()
    {
        if ((playerMoveScript.canDoubleJump || !playerMoveScript.jumped) && !playerMoveScript.onGround && !playerMoveScript.onSlope)
        {
            playerMoveScript.jumped = true;
            playerRb.gravityScale = 1.5f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(Vector2.up * (jumpForce * .75f), ForceMode2D.Impulse);
            playerMoveScript.canDoubleJump = false;
        }
        
    }
}
