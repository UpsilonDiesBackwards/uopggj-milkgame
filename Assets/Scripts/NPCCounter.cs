using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NPCCounter : InteractableObject
{
    public GameObject inventoryObj;
    Inventory inventory;
    bool AlreadySpokenTo = false;
    
    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    public void Update()
    {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E) && AlreadySpokenTo == false)
        {
            Debug.Log("Inventory: " + inventory.NPCCount);
            inventory.NPCCount++;
            AlreadySpokenTo = true;
        }

    }
 
}
