using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryStuff : MonoBehaviour
{
    public InventoryObject Inventory;
    public GameObject Isystem;
    
    public void addItem(Button b1)
    {
        Debug.Log("test");
        var item = b1.GetComponent<ItemThink>();
        // if (!Isystem.GetComponent<InventoryMenu>().playerInventoryFull)
        // {
            
            if (!b1.GetComponent<InventoryButton>().isSelected && b1.GetComponent<InventoryButton>().isUnlocked && Isystem.GetComponent<InventoryMenu>().numSelected < 3)
            {
                Inventory.AddItem(item.item, 1);
            }

        // }
        if (b1.GetComponent<InventoryButton>().isSelected && b1.GetComponent<InventoryButton>().isUnlocked)
        {
            Inventory.AddItem(item.item, -1);
        }
        
    }   
}
