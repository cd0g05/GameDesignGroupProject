using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private HealthController healthControllerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        healthControllerScript.playerHealth = healthControllerScript.playerHealth - damage;
        healthControllerScript.UpdateHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
