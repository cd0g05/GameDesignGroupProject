using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float shieldCooldown;
    [SerializeField] private float shieldTimer;
    private HealthController healthControllerScript;
    void Start()
    {
        shieldTimer = 5;
        shieldCooldown = 5;
        transform.parent = GameObject.Find("Player").transform;
        GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Shield").GetComponent<SphereCollider>().enabled = false;
        healthControllerScript = GameObject.Find("HealthController").GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldCooldown > 0)
        {
            shieldCooldown -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Y) && shieldCooldown <= 0 && !GameObject.Find("HealthController").GetComponent<HealthController>().dead)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SphereCollider>().enabled = true;
            GameObject.Find("Player").GetComponent<SpriteRenderer>().color= new Color(255, 255, 255, (float) 175/255);
            shieldCooldown = 10;
            StartCoroutine(Shield());
            //GameObject.Find("HealthController").GetComponent<HealthController>().UseShield(shieldTimer);
        }
    }

    private IEnumerator Shield()
    {
        print("ShieldUsed");
        healthControllerScript.canTakeDamage = false;
        yield return new WaitForSeconds(shieldTimer);
        GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Shield").GetComponent<SphereCollider>().enabled = false;
        healthControllerScript.canTakeDamage = true;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
