using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Equipment,
    Default

}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public ItemType type;
}

