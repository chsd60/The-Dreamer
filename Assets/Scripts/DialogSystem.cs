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
    private AudioSource source;
    private AudioClip[] voices;

    public GameObject continueButton;

    public GameObject downArrow;
    private bool activeCheck;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !activeCheck) {
            downArrow.SetActive(true);
            activeCheck = true;
            Debug.Log("Enter");
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (Input.GetButtonDown("Down")) {
                Type();
            }

        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && activeCheck) {
            downArrow.SetActive(false);
            activeCheck = false;
            Debug.Log("Exit");
        }
    }

    IEnumerator Type() {

        foreach(char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    private void Update() {
        if(textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
    }

    public void NextSentence() {

        source.Play();
        continueButton.SetActive(false);

        if (index < sentences.Length - 1) {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
