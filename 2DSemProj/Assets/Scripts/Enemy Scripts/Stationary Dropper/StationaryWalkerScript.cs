using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryWalkerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D stationaryFallingRb;
    private Transform stationaryFallingTrans;
    [SerializeField] private bool ableToFlip;
    private bool flipped = false;
    private bool walkingRight = true;
    public GameObject trigger;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        stationaryFallingRb = GetComponent<Rigidbody2D>();
        stationaryFallingTrans = GetComponent<Transform>();
    }

    public void Drop()
    {
        stationaryFallingRb.isKinematic = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (flipped == false && ableToFlip == true)
            {
                flipped = true;
                transform.Rotate(Vector3.forward * -180);
            }
        }
        if (collision.gameObject.CompareTag("Walls"))
        {
            walkingRight = !walkingRight;
            if (walkingRight)
            {
                //facing right
                stationaryFallingTrans.localScale = new Vector3(-Mathf.Abs(stationaryFallingTrans.localScale.x), stationaryFallingTrans.localScale.y, stationaryFallingTrans.localScale.z);
            }
            else if (!walkingRight)
            {
                //facing left
                stationaryFallingTrans.localScale = new Vector3(Mathf.Abs(stationaryFallingTrans.localScale.x), stationaryFallingTrans.localScale.y, stationaryFallingTrans.localScale.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        trigger.transform.position = enemy.transform.position;
        if (flipped == true)
        {
            if (walkingRight)
            {
                stationaryFallingRb.velocity = new Vector2(speed, stationaryFallingRb.velocity.y);
            }
            else if (!walkingRight)
            {
                stationaryFallingRb.velocity = new Vector2(-speed, stationaryFallingRb.velocity.y);
            }
        }
    }
}
