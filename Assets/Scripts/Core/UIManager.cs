using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public void OpenDialogue(string dialogueToDisplay) {
        dialogueText.gameObject.SetActive(true);
        dialogueText.GetComponent<TextMeshProUGUI>().text = dialogueToDisplay;
    }

    public void CloseDialogue() {
        dialogueText.gameObject.SetActive(false);
        dialogueText.GetComponent<TextMeshPro>().text = "";
    }
}
