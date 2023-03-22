using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float shieldCooldown;
    [SerializeField] private float shieldTimer;
    void Start()
    {
        shieldTimer = 5;
        shieldCooldown = 5;
        transform.parent = GameObject.Find("Player").transform;
        transform.localPosition = new Vector2(0.55f, 0);
        GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Shield").GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldCooldown > 0)
        {
            shieldCooldown -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Y) && shieldCooldown <= 0)
        {
            GameObject.Find("Shield").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Shield").GetComponent<BoxCollider2D>().enabled = true;
            shieldCooldown = 10;
            GameObject.Find("HealthController").GetComponent<HealthController>().UseShield(shieldTimer);
        }
    }
}
