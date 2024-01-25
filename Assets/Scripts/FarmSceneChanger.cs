using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FarmSceneChanger : MonoBehaviour
{
    public string targetSceneName;
    private bool isPlayerNear = false;

    void Update() {
        if (isPlayerNear == true) {
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
