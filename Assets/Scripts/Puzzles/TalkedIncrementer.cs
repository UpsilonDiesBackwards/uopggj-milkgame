using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TalkedIncrementer : MonoBehaviour
{
    private bool isPlayerNear = false;

    public void Update() {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) {
            GlobalGameplayVariables.Instance.amountSpokenToo++;
            GetComponent<TalkedIncrementer>().enabled = false;
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
