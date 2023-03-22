using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMod : MonoBehaviour
{
    [SerializeField] private float gravityMod;
    [SerializeField] private bool gravityChanged;
    private float cooldown;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 3;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F) && cooldown <= 0)
        {
            StartCoroutine(ChangeGravity());
        }
    }

    private IEnumerator ChangeGravity()
    {
        Physics2D.gravity = new Vector2(0, -gravityMod);
        gravityChanged = true;
        yield return new WaitForSeconds(timer);
        Physics2D.gravity = new Vector2(0, -9.8f);
        cooldown = 3;
        gravityChanged = false;
    }
}
