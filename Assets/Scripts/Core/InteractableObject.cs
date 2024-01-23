using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject UI;

    [TextArea(5,5)]
    public string Dialouge;
    private bool isPlayerNear = false;

    void Start() {
        UI = GameObject.FindGameObjectWithTag("UserInterface");
    }

    void Update() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            UI.GetComponent<UIManager>().OpenDialogue(Dialouge);
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
