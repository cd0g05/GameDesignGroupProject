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
        if (Input.GetKeyDown("u"))
        {
            CheckToSeeUnlocked();
            Debug.Log("u is pressed");

        }
    }

    public void ChangeSelection()
    {
        //check if there are already 3 items selected
        isSelected = !isSelected;
    }

    //checks to see if ability is in inventory, if so then button setting is unlocked
    private void CheckToSeeUnlocked()
    {
        for (int k = 0; k < 100; k++)
        {
            if (abilityInventory.Container[k].item.Equals(item))
            {
                isUnlocked = true;
                Debug.Log("Unlocked");

                return;
            }
            Debug.Log("Item checked is " + k);
        }
        isUnlocked = false;
        Debug.Log("checking");
    }
}
