using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryStuff : MonoBehaviour
{

    public InventoryObject Inventory;
    

     void OnTriggerEnter2D(Collider2D other)
    {

        
        // Debug.Log("touching");


        
        var item = other.GetComponent<ItemThink>();
        if (item)
        {

            Inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
            Debug.Log("Theoreticaly Added Item");
        }

    }   
}
