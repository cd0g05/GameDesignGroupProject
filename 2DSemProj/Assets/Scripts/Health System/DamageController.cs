using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private HealthController healthControllerScript;
    GameObject healthController;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
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
        healthController = GameObject.Find("HealthController");
        healthControllerScript = healthController.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
