using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Curtain : MonoBehaviour
{
    public Sprite opened;
    private bool isPlayerNear = false;

    public AudioClip curtainSound;
    private bool isOpen;

    public float choiceDelay = 12.0f;
    private bool startCountdown = false;

    public void Update() {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) {
            gameObject.GetComponent<SpriteRenderer>().sprite = opened;
        
            AudioSource aSource = GetComponent<AudioSource>();
            if (aSource == null) {
                aSource = gameObject.AddComponent<AudioSource>();
            }

            if (!isOpen) {
                aSource.clip = curtainSound;
                aSource.Play();
                isOpen = true;
            }

            startCountdown = true;
        }

        if (startCountdown) {
            choiceDelay -= Time.deltaTime;
        }

        if (choiceDelay <= 0.0) {
            SceneManager.LoadScene("LeChoice");
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
