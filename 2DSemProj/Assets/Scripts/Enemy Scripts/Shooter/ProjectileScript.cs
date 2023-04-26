using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D projectileRb;
    GameObject target;
    Vector2 moveDirection;
    [SerializeField] private int damage;
    GameObject shooter;
    [SerializeField] private Shooter shooterScript;

    [SerializeField] private HealthController healthControllerScript;
    GameObject healthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
            Destroy(gameObject);
            if (shooterScript.canFire == true)
            {
                shooterScript.Fire();
            }
        }
    }

    void Damage()
    {
        if (healthControllerScript.canTakeDamage)
        {
            healthControllerScript.playerHealth = healthControllerScript.playerHealth - damage;
            healthControllerScript.UpdateHealth();
            healthControllerScript.PlayerDamage();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        projectileRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        healthController = GameObject.Find("HealthController");
        healthControllerScript = healthController.GetComponent<HealthController>();
        shooter = GameObject.Find("Shooter");
        shooterScript = shooter.GetComponent<Shooter>();
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }*/


    // Update is called once per frame
    void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y).normalized * speed;
    }
}
