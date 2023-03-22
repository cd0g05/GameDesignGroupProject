using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowshooter : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;
    public bool canShoot = true;
    public Vector2 travelPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && canShoot) 
        {
            Vector2 travelPos = player.transform.position;
            Instantiate(arrow, travelPos, arrow.transform.rotation);
            canShoot = false;
            StartCoroutine(pause());

        }
        
    }

    public IEnumerator pause()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;
    }

}
