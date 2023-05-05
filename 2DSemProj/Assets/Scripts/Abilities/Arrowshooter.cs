using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowshooter : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;
    public bool canShoot = true;
    private bool abilityActive;
    public Vector2 travelPos;
    public bool equiped;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w") && canShoot && abilityActive) 
        {
            Vector2 travelPos = player.transform.position;
            Instantiate(arrow, travelPos, arrow.transform.rotation);
            canShoot = false;
            StartCoroutine(pause());

        }
        
    }

    public void Equip_Unequip()
    {
        if (equiped)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            equiped = false;
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            Use();
            equiped = true;
        }
    }

    public IEnumerator pause()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;
    }

    private IEnumerator AbilityCooldown()
    {
        yield return new WaitForSeconds(10);
        abilityActive = false;
    }

    public void Use()
    {
        abilityActive = true;
        StartCoroutine(AbilityCooldown());
    }

}
