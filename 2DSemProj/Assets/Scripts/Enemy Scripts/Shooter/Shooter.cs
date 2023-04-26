using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private float fireRate;
    private float nextFire;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        Fire();
        //fireRate = 10f;
        //nextFire = Time.time;
    }

    public void Fire()
    {
        if (canFire == true)
        { 
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        canFire = false;
        yield return new WaitForSeconds(2);
        Instantiate(projectile, transform.position, Quaternion.identity);
        canFire = true;
    }

    // Update is called once per frame
    /*void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }*/
}
