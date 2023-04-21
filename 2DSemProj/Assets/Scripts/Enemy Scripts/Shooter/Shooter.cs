using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        Fire();
        //fireRate = 10f;
        //nextFire = Time.time;
    }

    public void Fire()
    {
        StartCoroutine(Wait());
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
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
