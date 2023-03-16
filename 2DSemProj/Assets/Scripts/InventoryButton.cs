using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public bool isSelected { get; private set; }
    public bool isUnlocked;//{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
