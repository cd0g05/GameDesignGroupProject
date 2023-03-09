using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryDropperTriggerScript : MonoBehaviour
{
    private Rigidbody2D stationaryFallingRb;
    private Transform stationaryFallingTrans;
    [SerializeField] private StationaryWalkerScript stationaryWalkerScript;

    // Start is called before the first frame update
    void Start()
    {
        stationaryFallingRb = GetComponent<Rigidbody2D>();
        stationaryFallingTrans = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stationaryWalkerScript.Drop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
