using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedDialogue : MonoBehaviour {
    public bool cutsceneHasHappened = false;
    public bool hasEntered = false;
    public bool hasEnded = false;
    public GameObject dialogue;
    public GameObject dialogueTrigger;
    private CharacterController2D characterController2D;
    private PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D other) {
        hasEntered = true;
        playerMovement = other.gameObject.GetComponent<PlayerMovement>();
        characterController2D = other.gameObject.GetComponent<CharacterController2D>();

    }

    private void OnTriggerExit2D(Collider2D other) {
        hasEntered = false;
    }
    private void Update() {
        if (cutsceneHasHappened == false && hasEntered == true) {
            GetComponent<DialogSystem>().StartCoroutine("StartDialogue");
            Debug.Log("Entrato");
            cutsceneHasHappened = true;
        }

        if (hasEntered == true) {
            playerMovement.horizontalMove = 0f;
            characterController2D.enabled = false;
            playerMovement.enabled = false;
        }

        if (hasEnded == true) {
            dialogueTrigger.SetActive(false);
        }
    }

    public void DialogEnding() {
        hasEnded = true;
    }
}
