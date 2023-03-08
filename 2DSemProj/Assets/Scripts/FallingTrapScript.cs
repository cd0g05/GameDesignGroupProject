using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrapScript : MonoBehaviour
{
    private Rigidbody2D fallingRb;

    // Start is called before the first frame update
    void Start()
    {
        fallingRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fallingRb.isKinematic = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
