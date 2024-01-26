using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassChecker : MonoBehaviour
{
    public GameObject door;

    public GameObject BeforeGlass;
    public GameObject AfterGlass;

    void Start() {
        if (!GlobalGameplayVariables.Instance.hasMilkGlass) {
            BeforeGlass.SetActive(true);
            AfterGlass.SetActive(false);
        } else {
            BeforeGlass.SetActive(false);
            AfterGlass.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalGameplayVariables.Instance.hasMilkGlass)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
