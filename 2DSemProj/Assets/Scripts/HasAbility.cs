using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasAbility : MonoBehaviour
{
    //Variables


    [SerializeField] public InventoryObject Inventory;

    public bool hasAbility1 = false;
    public bool hasAbility2 = false;
    public bool hasAbility3 = false;
    public bool hasAbility4 = false;
    public bool hasAbility5 = false;
    public bool hasAbility6 = false;
    public bool hasAbility7 = false;
    public bool hasAbility8 = false;
    public bool hasAbility9 = false;
    public bool hasAbility10 = false;
    public bool hasAbility11 = false;
    public bool hasAbility12 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetAbility1();
        SetAbility2();
        SetAbility3();
        SetAbility4();
        SetAbility5();
    }
    
    //Goes through inventory and checks if the item amount is one

    public void SetAbility1()
    {
        Debug.Log(Inventory.Container[0].amount);
        if (Inventory.Container[0].amount.Equals(1))
        {
            hasAbility1 = true;
            Debug.Log("Set ability 1 to true");

        }
        else
        {
            hasAbility1 = false;
            Debug.Log("Set ability 1 to false");

        }

    }
    public void SetAbility2()
    {
        if (Inventory.Container[1].amount.Equals(1))
        {
            hasAbility2 = true;
            Debug.Log("Set ability 2 to true");
        }
        else
        {
            hasAbility2 = false;
            Debug.Log("Set ability 2 to false");

        }
    }
    public void SetAbility3()
    {
        if (Inventory.Container[2].amount.Equals(1))
        {
            hasAbility3 = true;
            Debug.Log("Set ability 3 to true");
        }
        else
        {
            hasAbility3 = false;
            Debug.Log("Set ability 3 to false");

        }
        
    }
    public void SetAbility4()
    {
        if (Inventory.Container[3].amount.Equals(1))
        {
            hasAbility4 = true;
            Debug.Log("Set ability 4 to true");
        }
        else
        {
            hasAbility4 = false;
            Debug.Log("Set ability 4 to false");

        }
        
    }
    public void SetAbility5()
    {
        if (Inventory.Container[4].amount.Equals(1))
        {
            hasAbility5 = true;
            Debug.Log("Set ability 5 to true");
        }
        else
        {
            hasAbility5 = false;
            Debug.Log("Set ability 5 to false");

        }
        
    }



}
