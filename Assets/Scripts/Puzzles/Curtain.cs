using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    public Sprite opened;
    private bool isPlayerNear = false;

    public void Update() {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) {
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
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
