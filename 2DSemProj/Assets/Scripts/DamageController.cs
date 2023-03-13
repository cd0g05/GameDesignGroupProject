using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private HealthController healthControllerScript;

    private bool iFramesActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    void Damage()
    {
        if (iFramesActive == false)
        {
            healthControllerScript.playerHealth = healthControllerScript.playerHealth - damage;
            healthControllerScript.UpdateHealth();
            iFramesActive = true;
            StartCoroutine(IFramesCountdown());
        }
    }

    IEnumerator IFramesCountdown()
    {
        yield return new WaitForSeconds(1);
        iFramesActive = false;
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
