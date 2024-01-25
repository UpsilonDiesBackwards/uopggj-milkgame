using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CodeBox : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) { 
                Pause();
            }
            else {
                UnPause();
            }
            
        }
    }

    public void Pause() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void UnPause() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
