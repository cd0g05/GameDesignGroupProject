using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private List<Button> inventoryButtons = new List<Button>();
    [SerializeField] private Button continueButton;
    private ScriptableObject gameInevntory;
    public bool playerInventoryFull { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerInventoryFull = false;
        foreach (Button item in inventoryButtons)
        {
            if (!item.GetComponent<InventoryButton>().isUnlocked)
            {
                item.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                item.GetComponent<Image>().color = Color.white;
            }
        }

        //setting continue button color
        if (!playerInventoryFull)
        {
            continueButton.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            continueButton.GetComponent<Image>().color = Color.white;
        }

    }

    // Update is called once per frame
    void Update()
    {
        int numSelected = 0;

        foreach (Button item in inventoryButtons)
        {
            if (item.GetComponent<InventoryButton>().isSelected)
            {
                numSelected++;
            }
        }

        if (numSelected >= 3)
        {
            playerInventoryFull = true;
        }
        else
        {
            playerInventoryFull = false;
        }
        
    }

    public void SelectOrDeselectItem(Button item)
    {
        if (item.GetComponent<InventoryButton>().isSelected)
        {
            item.GetComponent<InventoryButton>().ChangeSelection();
            item.GetComponent<Image>().color = Color.white;
            //move item to level inventory
        }

        else if (!item.GetComponent<InventoryButton>().isSelected)
        {
            if (item.GetComponent<InventoryButton>().isUnlocked && !playerInventoryFull)
            {
                item.GetComponent<InventoryButton>().ChangeSelection();
                item.GetComponent<Image>().color = Color.green;
            }
        }
    }

 
}

//1. show all available abilities and items
//2. player chooses items, when picked they go to level inventory
//3. after 3 abilities are chosen they can't choose anymore