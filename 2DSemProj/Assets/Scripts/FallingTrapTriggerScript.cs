using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrapTriggerScript : MonoBehaviour
{
    private Rigidbody2D fallingTrapRb;
    private Transform fallingTrapRbTrans;
    [SerializeField] private FallingTrapScript stationaryWalkerScript;

    // Start is called before the first frame update
    void Start()
    {
        fallingTrapRb = GetComponent<Rigidbody2D>();
        fallingTrapRbTrans = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stationaryWalkerScript.Drop();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
