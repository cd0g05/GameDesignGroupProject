using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D projectileRb;
    GameObject target;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        projectileRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
