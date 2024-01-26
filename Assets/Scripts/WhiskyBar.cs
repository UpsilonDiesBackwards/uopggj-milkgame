using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiskyBar : MonoBehaviour
{
    GameObject inventoryObj;
    Inventory inventory;

    public string targetSceneName;
    private bool isPlayerNear = false;

    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        inventory = inventoryObj.GetComponent<Inventory>();
    }

    void Update() {
        LoadScene();
    }

    void LoadScene() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            SceneManager.LoadScene(targetSceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
           isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player")) {
           isPlayerNear = false;
        }
    }
}
