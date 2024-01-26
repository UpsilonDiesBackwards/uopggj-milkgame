using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)) {
            SceneManager.LoadScene("EndingDad");
        }

        if (Input.GetKeyUp(KeyCode.E)) {
            SceneManager.LoadScene("EndingMilk");
        }
    }
}
