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
        SetAbility6();
        SetAbility7();
        SetAbility8();
        SetAbility9();
        SetAbility10();
        SetAbility11();
        SetAbility12();

    }
    
    //Goes through inventory and checks if the item amount is one

    public void SetAbility1()
    {
        if (Inventory.Container[0].amount.Equals(1) && !hasAbility1)
        {
            hasAbility1 = true;
            Debug.Log("Set ability 1 to true");

        }
        else if(Inventory.Container[0].amount.Equals(0) && hasAbility1)
        {
            hasAbility1 = false;
            Debug.Log("Set ability 1 to false");

        }

    }
    public void SetAbility2()
    {
        if (Inventory.Container[1].amount.Equals(1) && !hasAbility2)
        {
            hasAbility2 = true;
            Debug.Log("Set ability 2 to true");
        }
        else if(Inventory.Container[1].amount.Equals(0) && hasAbility2)
        {
            hasAbility2 = false;
            Debug.Log("Set ability 2 to false");

        }
    }
    public void SetAbility3()
    {
        if (Inventory.Container[2].amount.Equals(1) && !hasAbility3)
        {
            hasAbility3 = true;
            Debug.Log("Set ability 3 to true");
        }
        else if(Inventory.Container[2].amount.Equals(0) && hasAbility3)
        {
            hasAbility3 = false;
            Debug.Log("Set ability 3 to false");

        }
        
    }
    public void SetAbility4()
    {
        if (Inventory.Container[3].amount.Equals(1) && !hasAbility4)
        {
            hasAbility4 = true;
            Debug.Log("Set ability 4 to true");
        }
        else if(Inventory.Container[3].amount.Equals(0) && hasAbility4)
        {
            hasAbility4 = false;
            Debug.Log("Set ability 4 to false");

        }
        
    }
    public void SetAbility5()
    {
        if (Inventory.Container[4].amount.Equals(1) && !hasAbility5)
        {
            hasAbility5 = true;
            Debug.Log("Set ability 5 to true");
        }
        else if(Inventory.Container[4].amount.Equals(0) && hasAbility5)
        {
            hasAbility5 = false;
            Debug.Log("Set ability 5 to false");

        }
        
    }
    public void SetAbility6()
    {
        if (Inventory.Container[5].amount.Equals(1) && !hasAbility6)
        {
            hasAbility6 = true;
            Debug.Log("Set ability 6 to true");

        }
        else if(Inventory.Container[5].amount.Equals(0) && hasAbility6)
        {
            hasAbility6 = false;
            Debug.Log("Set ability 6 to false");

        }

    }
    public void SetAbility7()
    {
        if (Inventory.Container[6].amount.Equals(1) && !hasAbility7)
        {
            hasAbility7 = true;
            Debug.Log("Set ability 7 to true");
        }
        else if(Inventory.Container[6].amount.Equals(0) && hasAbility7)
        {
            hasAbility7 = false;
            Debug.Log("Set ability 7 to false");

        }
    }
    public void SetAbility8()
    {
        if (Inventory.Container[7].amount.Equals(1) && !hasAbility8)
        {
            hasAbility8 = true;
            Debug.Log("Set ability 8 to true");
        }
        else if(Inventory.Container[7].amount.Equals(0) && hasAbility8)
        {
            hasAbility8 = false;
            Debug.Log("Set ability 8 to false");

        }
        
    }
    public void SetAbility9()
    {
        if (Inventory.Container[8].amount.Equals(1) && !hasAbility9)
        {
            hasAbility9 = true;
            Debug.Log("Set ability 9 to true");
        }
        else if(Inventory.Container[8].amount.Equals(0) && hasAbility9)
        {
            hasAbility9 = false;
            Debug.Log("Set ability 9 to false");

        }
        
    }
    public void SetAbility10()
    {
        if (Inventory.Container[9].amount.Equals(1) && !hasAbility10)
        {
            hasAbility10 = true;
            Debug.Log("Set ability 10 to true");
        }
        else if(Inventory.Container[9].amount.Equals(0) && hasAbility10)
        {
            hasAbility10 = false;
            Debug.Log("Set ability 10 to false");

        }
        
    }
    public void SetAbility11()
    {
        if (Inventory.Container[10].amount.Equals(1) && !hasAbility11)
        {
            hasAbility11 = true;
            Debug.Log("Set ability 11 to true");
        }
        else if(Inventory.Container[10].amount.Equals(0) && hasAbility11)
        {
            hasAbility11 = false;
            Debug.Log("Set ability 11 to false");

        }
        
    }
    public void SetAbility12()
    {
        if (Inventory.Container[11].amount.Equals(1) && !hasAbility12)
        {
            hasAbility12 = true;
            Debug.Log("Set ability 12 to true");
        }
        else if(Inventory.Container[11].amount.Equals(0) && hasAbility12)
        {
            hasAbility12 = false;
            Debug.Log("Set ability 12 to false");

        }
        
    }


}
