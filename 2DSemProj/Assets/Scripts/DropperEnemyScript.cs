using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperEnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool onGround;
    private Rigidbody2D dropperRb;
    private Transform dropperTrans;
    private BoxCollider2D dropperBc;
    private bool walkingRight = true;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        dropperRb = GetComponent<Rigidbody2D>();
        dropperBc = GetComponent<BoxCollider2D>();
        dropperTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingRight)
        {
            dropperRb.velocity = new Vector2(speed, dropperRb.velocity.y);
        }
        else if (!walkingRight)
        {
            dropperRb.velocity = new Vector2(-speed, dropperRb.velocity.y);
        }

        if (player.transform.position.x == dropperTrans.transform.position.x)
        {
            dropperRb.AddForce(new Vector2(0, -1));
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            walkingRight = !walkingRight;
            if (walkingRight)
            {
                //facing right
                dropperTrans.localScale = new Vector3(-Mathf.Abs(dropperTrans.localScale.x), dropperTrans.localScale.y, dropperTrans.localScale.z);
            }
            else if (!walkingRight)
            {
                //facing left
                dropperTrans.localScale = new Vector3(Mathf.Abs(dropperTrans.localScale.x), dropperTrans.localScale.y, dropperTrans.localScale.z);
            }
        }
    }
}
