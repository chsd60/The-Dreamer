using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedDialogue : MonoBehaviour {
    public bool cutsceneHasHappened = false;
    public bool hasEntered = false;
    public bool hasEnded = false;
    private GameObject playerGameObject;
  

    private void OnTriggerEnter2D(Collider2D other) {
        hasEntered = true;
        playerGameObject = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        hasEntered = false;
    }
    private void Update() {
        if (cutsceneHasHappened == false && hasEntered == true) {
            GetComponent<DialogSystem>().StartCoroutine("StartDialogue");
            Debug.Log("Entrato");
            playerGameObject.GetComponent<CharacterController2D>().enabled = false;
            playerGameObject.GetComponent<PlayerMovement>().enabled = false;
            playerGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            cutsceneHasHappened = true;
        }       
    }

    public void DialogEnding() {
        playerGameObject.GetComponent<CharacterController2D>().enabled = true;
        playerGameObject.GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.SetActive(false);
        hasEnded = true;
    }
}
