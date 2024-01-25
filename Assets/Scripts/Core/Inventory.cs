using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] items;

    public void AddItem(Item item)
    {
        Debug.Log(item.itemID);
        items[item.itemID] = item;
    }
}
