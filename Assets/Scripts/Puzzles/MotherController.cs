using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    public GameObject player;
    public bool isPlayerNear = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            GlobalGameplayVariables.Instance.hasHouseKey = true;
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
