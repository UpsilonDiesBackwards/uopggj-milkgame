using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableObject
{
    GameObject inventoryObj;
    Inventory inventory;
    public string itemName;
    public int itemID;

    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E))
        {
            inventory.AddItem(gameObject.GetComponent<Item>());
        }
    }
}
