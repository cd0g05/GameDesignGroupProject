using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float damage;
    private Animator swordAnimator;
    private Animation swordAnimation;
    private float swingCountdown;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
        swordAnimation = GetComponent<Animation>();
        damage = 20;
        transform.parent = GameObject.Find("Player").transform;
        transform.localPosition = new Vector2(1.14f, .25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && swingCountdown <= 0)
        {
            swordAnimator.SetTrigger("Swing");
            swingCountdown = .75f;
            isAttacking = true;
            StartCoroutine(AttackingCountdown());
        }

        if (swingCountdown > 0)
        {
            swingCountdown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private IEnumerator AttackingCountdown()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            print("Hit");
            Destroy(collision.gameObject);
        }
    }
}
