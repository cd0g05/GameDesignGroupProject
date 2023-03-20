using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryStuff : MonoBehaviour
{

    public Button b1;
    
    public void addItem(InventoryObject Inventory)
    {
        Debug.Log("test");
        var item = b1.GetComponent<ItemThink>();
        
           
        Inventory.AddItem(item.item, 1);
        
        
    }   
}
