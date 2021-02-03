using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private int index;
    public float typingSpeed;
    public AudioSource source;
    public string[] sentences;
    public AudioClip[] voices;

    public UnityEvent endedDialogueAction;
    public GameObject continueButton;
    public GameObject textBackground;

    [HideInInspector] public bool hasEntered = false;
    [HideInInspector] public bool dialogueInProgress = false;
    [HideInInspector] public bool typingInProgress = false;

    private void OnTriggerEnter2D(Collider2D other) {
        hasEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        hasEntered = false;
        //Finisce forzatamente il dialogo se il personaggio esce dal trigger
        if (dialogueInProgress == true) {
            Invoke(nameof(EndDialogue), 0f);
        }
    }
    void Update() {
        if (Input.GetButtonDown("Down") && hasEntered == true && dialogueInProgress == false) {
            StartDialogue();
            Debug.Log("DialogoInizio");
        }

        if (Input.GetButtonDown("Down") && dialogueInProgress == true && typingInProgress == false) {
            Invoke(nameof(NextSentence), 0.1f);
            Debug.Log("NextSentence");
        }

    }
    IEnumerator Type() {
        textBackground.SetActive(true);
        continueButton.SetActive(false);
        AudioClip audio = voices[index];
        source.clip = audio;
        source.Play();
        typingInProgress = true;

        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            Debug.Log("Scrivo");
        }

        continueButton.SetActive(true);
        typingInProgress = false;
    }

    public void NextSentence() {

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else {
            Invoke(nameof(EndDialogue), 0f);
        }
    }

    public void EndDialogue() {
        textDisplay.text = "";
        continueButton.SetActive(false);
        textBackground.SetActive(false);
        dialogueInProgress = false;
        index = 0;
        endedDialogueAction.Invoke();
    }

    public void StartDialogue() {
        StartCoroutine(Type());
        dialogueInProgress = true;
    }
}
