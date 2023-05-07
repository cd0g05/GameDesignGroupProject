using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private AudioSource swordSound;
    private float damage;
    private Animator swordAnimator;
    private Animation swordAnimation;
    private float swingCountdown;
    private bool isAttacking;
    private int swordDurability;
    public int limit = 5;
    public GameObject sword;
    public bool equiped;

    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
        swordAnimation = GetComponent<Animation>();
        damage = 20;
        transform.parent = GameObject.Find("Player").transform;
        transform.localPosition = new Vector2(1.14f, .25f);
        swordDurability = 0;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && swingCountdown <= 0 && equiped)
        {
            Use();
        }

        if (swingCountdown > 0)
        {
            swingCountdown -= Time.deltaTime;
        }
        if (swordDurability >= limit)
        {
            StartCoroutine(deletesword());
        }
    }

    public void Equip_Unequip()
    {
        if (equiped)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            equiped = false;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            equiped = true;
        }
    }

    public void Use()
    {
        swordSound.Play();
        swordAnimator.SetTrigger("Swing");
        swingCountdown = .75f;
        swordDurability++;
        Debug.Log(swordDurability);
        isAttacking = true;
        StartCoroutine(AttackingCountdown());
    }
    private IEnumerator deletesword()
    {
        yield return new WaitForSeconds(0.4f);
        sword.SetActive(false);


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
