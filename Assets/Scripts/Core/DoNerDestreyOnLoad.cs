using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNerDestreyOnLoad : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
