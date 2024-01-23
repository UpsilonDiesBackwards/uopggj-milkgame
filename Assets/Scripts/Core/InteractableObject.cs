using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [TextArea(5,5)]
    public String Dialouge;
    private bool isPlayerNear = false;

    void Update() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            Debug.Log(Dialouge);
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
