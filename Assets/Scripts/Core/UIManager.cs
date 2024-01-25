using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;

    [Header("Dialogue")]
    private List<string> currentDialogueLines = new List<string>();
    public TextMeshProUGUI dialogueText;
    public float dialogueTypeSpeed;
    public float advanceDelay = 1;
    public AudioClip yapSound;
    public float minYapPitch = 0.2f;
    public float maxYapPitch = 1.2f;
    private bool typing = false;
    private bool canAdvanceDialogue = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OpenDialogue(List<string> dialogue) {
        if (canAdvanceDialogue)
        {
            currentDialogueLines = dialogue;
            StartCoroutine(TypeDialogue());

            canAdvanceDialogue = false;
            player.GetComponent<PlayerController>().freeze = true;
        }
    }

    public void CloseDialogue() {
        dialogueText.gameObject.SetActive(false);
        dialogueText.text = "";
    }
    
    IEnumerator TypeDialogue()
    {
        typing = true;
        dialogueText.gameObject.SetActive(true);
        
        foreach (string line in currentDialogueLines) {
            dialogueText.text = "";

            foreach (char letter in line) {
                if (!char.IsWhiteSpace(letter)) {
                    PlayYapSound();
                }
            
                dialogueText.text += letter;
                yield return new WaitForSeconds(dialogueTypeSpeed);
            }
            yield return new WaitForSeconds(advanceDelay);
        }

        typing = false;
        // currentDialogueLines.Clear();
        canAdvanceDialogue = true;
        player.GetComponent<PlayerController>().freeze = false;
        
        CloseDialogue();
    }

    void PlayYapSound() {
        if (yapSound == null) {
            return;
        }
        AudioSource aSource = GetComponent<AudioSource>();
        if (aSource == null) {
            aSource = gameObject.AddComponent<AudioSource>();
        }

        aSource.clip = yapSound;
        aSource.pitch = Random.Range(minYapPitch, maxYapPitch);
        aSource.Play();
    }
}
