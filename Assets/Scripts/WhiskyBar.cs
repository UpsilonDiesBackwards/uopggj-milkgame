using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiskyBar : MonoBehaviour
{
    public bool requiresKey = false;

    public string targetSceneName;
    private bool isPlayerNear = false;

    void Update() {
        LoadScene();
    }

    void LoadScene() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            if (!requiresKey) { SceneManager.LoadScene(targetSceneName); }

            if (requiresKey && GlobalGameplayVariables.Instance.hasHouseKey) {
                SceneManager.LoadScene(targetSceneName);
            }
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
