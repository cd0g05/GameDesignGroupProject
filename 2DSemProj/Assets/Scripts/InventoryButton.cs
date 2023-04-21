using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public bool isSelected { get; private set; }
    public bool isUnlocked;//{ get; private set; }
    [SerializeField] public ItemObject item;

    public InventoryObject abilityInventory;

    private void Awake()
    {
        CheckToSeeUnlocked();
    }
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSelection()
    {
        //check if there are already 3 items selected
        isSelected = !isSelected;
    }

    private void CheckToSeeUnlocked()
    {
        for (int k = 0; k < abilityInventory.Container.Count; k++)
        {
            if (abilityInventory.Container[k].Equals(item))
            {
                isUnlocked = true;
                return;
            }
        }
        isUnlocked = false;
    }
}
