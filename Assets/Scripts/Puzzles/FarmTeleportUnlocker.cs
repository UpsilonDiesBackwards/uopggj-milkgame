using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTeleportUnlocker : MonoBehaviour
{
    public GameObject BeforeTalk;
    public GameObject AfterTalk;

    public GameObject FarmTeleporter;

    void Update() {
        if (GlobalGameplayVariables.Instance.amountSpokenToo == 3) {
            BeforeTalk.SetActive(false);
            AfterTalk.SetActive(true);

        } else if (GlobalGameplayVariables.Instance.amountSpokenToo == 4) {
            FarmTeleporter.SetActive(true);
        }
    }
}
