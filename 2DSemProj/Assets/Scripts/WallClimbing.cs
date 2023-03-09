using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    private float cooldownTimer;
    private float timeCanUse;
    private bool canClimb;
    // Start is called before the first frame update
    void Start()
    {
        timeCanUse = 5;
        cooldownTimer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            canClimb = true;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
}
