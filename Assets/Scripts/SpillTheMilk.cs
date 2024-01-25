using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpillTheMilk : MonoBehaviour {
    // This handles the movement of the "milk" sprites during the startup animation

    [Header("Milk")] 
    public GameObject[] sprites;
    public float stopYPosition = -5f;
    public float speed = 7;

    [Header("Text and Buttons")] 
    public TextMeshProUGUI gameTitleText;
    public TextMeshProUGUI gameCreditText;

    public GameObject playButton;
    public bool isTextFadingIn = false;
    public float textFadeInDuration = 2f;

    private void Start() {
        playButton.SetActive(false);
        gameTitleText.color = new Color(gameTitleText.color.r, gameTitleText.color.g, gameTitleText.color.b, 0f);
        gameCreditText.color = new Color(gameCreditText.color.r, gameCreditText.color.g, gameCreditText.color.b, 0f);
    }

    void Update() {
        bool allSpritesReachedDestination = true;
        for (int i = 0; i < sprites.Length; i++) {
            Transform currentTransform = sprites[i].transform;

            Vector3 newPosition = currentTransform.position - new Vector3(0f, speed * Time.deltaTime, 0f);

            if (newPosition.y > stopYPosition) {
                currentTransform.position = newPosition;
                allSpritesReachedDestination = false;
            }
            else {
                currentTransform.position =
                    new Vector3(currentTransform.position.x, stopYPosition, currentTransform.position.z);
            }
        }

        if (allSpritesReachedDestination && !isTextFadingIn) {
            isTextFadingIn = true;
            StartCoroutine(FadeIn(textFadeInDuration, gameTitleText));
            StartCoroutine(FadeIn(textFadeInDuration, gameCreditText));
            playButton.SetActive(true);
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("LeHouse");
    }

    public IEnumerator FadeIn(float time, TextMeshProUGUI i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / time));
            yield return null;
        }
    }

    public IEnumerator FadeOut(float time, TextMeshProUGUI i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
