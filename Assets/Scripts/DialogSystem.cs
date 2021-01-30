using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public AudioSource source;
    public AudioClip[] voices;

    public GameObject continueButton;
    public GameObject textBackground;

    public bool hasEntered = false;
    public bool dialogueInProgress = false;
    public bool typingInProgress = false;

    private void OnTriggerEnter2D(Collider2D other) {
        hasEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        hasEntered = false;
        //Finisce forzatamente il dialogo se il personaggio esce dal trigger
        if (dialogueInProgress == true) {
            Invoke("EndDialogue", 0f);
        }
    }
    void Update() {
        if (Input.GetButtonDown("Down") && hasEntered == true && dialogueInProgress == false) {
            textBackground.SetActive(true);
            StartCoroutine(Type());
            dialogueInProgress = true;
            Debug.Log("DialogoInizio");
        }

        if (Input.GetButtonDown("Down") && dialogueInProgress == true && typingInProgress == false) {
            Invoke("NextSentence", 0.1f);
            Debug.Log("NextSentence");
        }

    }
    IEnumerator Type() {

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
            Invoke("EndDialogue", 0f);
        }
    }

    public void EndDialogue() {
        textDisplay.text = "";
        continueButton.SetActive(false);
        textBackground.SetActive(false);
        dialogueInProgress = false;
        index = 0;
    }
}
