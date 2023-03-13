using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrapScript : MonoBehaviour
{
    private Rigidbody2D fallingTrapRb;

    // Start is called before the first frame update
    void Start()
    {
        fallingTrapRb = GetComponent<Rigidbody2D>();
    }

    public void Drop()
    {
        fallingTrapRb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
