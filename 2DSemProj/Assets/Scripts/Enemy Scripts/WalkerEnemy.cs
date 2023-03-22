using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerEnemy : MonoBehaviour
{
    //declaring variables
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool onGround;
    private Rigidbody2D walkerRb;
    private Transform walkerTrans;
    private BoxCollider2D walkerBc;
    private bool walkingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        walkerRb = GetComponent<Rigidbody2D>();
        walkerBc = GetComponent<BoxCollider2D>();
        walkerTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingRight)
        {
            walkerRb.velocity = new Vector2(speed, walkerRb.velocity.y);
        }
        else if (!walkingRight)
        {
            walkerRb.velocity = new Vector2(-speed, walkerRb.velocity.y);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            walkingRight = !walkingRight;
            if(walkingRight)
            {
                //facing right
                walkerTrans.localScale = new Vector3(-Mathf.Abs(walkerTrans.localScale.x), walkerTrans.localScale.y, walkerTrans.localScale.z);
            } else if (!walkingRight)
            {
                //facing left
                walkerTrans.localScale = new Vector3(Mathf.Abs(walkerTrans.localScale.x), walkerTrans.localScale.y, walkerTrans.localScale.z);
            }
        }
    }
}
