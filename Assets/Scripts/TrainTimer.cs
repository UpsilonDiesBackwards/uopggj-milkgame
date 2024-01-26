using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class TrainTimer : MonoBehaviour
{
    public GameObject player;

    public float duration = 5.0f;
    public string targetSceneName;
    
    public AudioClip trainAmbience;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().freeze = true;

        AudioSource aSource = GetComponent<AudioSource>();
        if (aSource == null) {
            aSource = gameObject.AddComponent<AudioSource>();
        }

        aSource.clip = trainAmbience;
        aSource.Play();
    }

    void Update() {
        duration -= Time.deltaTime;

        if (duration <= 0.0f) {
            SceneManager.LoadScene(targetSceneName);
        }
    }


}
