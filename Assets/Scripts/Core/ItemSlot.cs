using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSlot : InteractableObject
{
    [SerializeField] string acceptedItem;

    GameObject inventoryObj;
    Inventory inventory;

    public string targetSceneName;

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
                if (item != null)
                {
                    Debug.Log(item.itemName);
                    Debug.Log(acceptedItem);
                    if (item.itemName == acceptedItem) {
                        SceneManager.LoadScene(targetSceneName);
                    }
                }
            }
        }
    }
}
