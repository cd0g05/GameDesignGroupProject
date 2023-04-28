using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAbility : MonoBehaviour
{
    public InventoryObject Inventory;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        var item = other.GetComponent<ItemThink>();
        Debug.Log(item);
        if (item)
        {
            Debug.Log("touching");
            Inventory.AddItem(item.item, 0);
            Destroy(other.gameObject);
        }

    }   
}
