using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryStuff : MonoBehaviour
{
    public InventoryObject Inventory;
    
    public void addItem(Button b1)
    {
        Debug.Log("test");
        var item = b1.GetComponent<ItemThink>();
        
           
        Inventory.AddItem(item.item, 1);
        
        
    }   
}
