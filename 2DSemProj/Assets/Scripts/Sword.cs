using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float damage;
    private Animator swordAnimator;
    private Animation swordAnimation;
    private float swingCountdown;

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
            swingCountdown = 3;
        }

        if (swingCountdown > 0)
        {
            swingCountdown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (swordAnimation.IsPlaying("Swing") && collision.gameObject.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<EnemyHealth>().AddDamage(damage);

        }
    }
}
