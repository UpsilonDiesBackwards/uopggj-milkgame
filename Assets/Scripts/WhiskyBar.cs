using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiskyBar : MonoBehaviour
{
    public bool requiresKey = false;

    public string targetSceneName;
    private bool isPlayerNear = false;

    public AudioClip doorSound;

    void Update() {
        LoadScene();
    }

    void LoadScene() {
        if (isPlayerNear == true && Input.GetKeyUp(KeyCode.E)) {
            if (!requiresKey) { SceneManager.LoadScene(targetSceneName); }

            if (requiresKey && GlobalGameplayVariables.Instance.hasHouseKey) {
                StartCoroutine(OpenDoor());
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

    void PlayDoorSound() {
        if (doorSound == null) {
            return;
        }
        AudioSource aSource = GetComponent<AudioSource>();
        if (aSource == null) {
            aSource = gameObject.AddComponent<AudioSource>();
        }

        if (!aSource.isPlaying) {
            aSource.clip = doorSound;
            aSource.Play();
        }
    }

    IEnumerator OpenDoor() {
        PlayDoorSound();
        new WaitForSeconds(doorSound.length);
        SceneManager.LoadScene(targetSceneName);
        yield return new WaitForEndOfFrame();
    }
}
