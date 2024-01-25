using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemSlot : InteractableObject
{
    [SerializeField] string acceptedItem;

    GameObject inventoryObj;
    Inventory inventory;

    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    public void Update()
    {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E))
        {
            foreach (Item item in inventory.items)
            {
                if (item.name == acceptedItem)
                {
                    //do the thing
                }
            }
        }
    }
}
