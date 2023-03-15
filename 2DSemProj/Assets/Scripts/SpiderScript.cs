using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    //declaring variables
    [SerializeField] private float speed;
    private Rigidbody2D spiderRb;
    private Transform spiderTrans;
    private BoxCollider2D spiderBc;
    private bool walkingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        spiderRb = GetComponent<Rigidbody2D>();
        spiderBc = GetComponent<BoxCollider2D>();
        spiderTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkingRight)
        {
            spiderRb.velocity = new Vector2(speed, spiderRb.velocity.y);
            spiderRb.AddForce(-1 * Physics.gravity);
        }
        else if (!walkingRight)
        {
            spiderRb.velocity = new Vector2(-speed, spiderRb.velocity.y);
            spiderRb.AddForce(-1 * Physics.gravity);
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
                spiderTrans.localScale = new Vector3(-Mathf.Abs(spiderTrans.localScale.x), spiderTrans.localScale.y, spiderTrans.localScale.z);
            }
            else if (!walkingRight)
            {
                //facing left
                spiderTrans.localScale = new Vector3(Mathf.Abs(spiderTrans.localScale.x), spiderTrans.localScale.y, spiderTrans.localScale.z);
            }
        }
    }
}
