using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedDialogue : MonoBehaviour {
    private bool cutsceneHasHappened = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (cutsceneHasHappened == false) {
            GetComponent<DialogSystem>().StartCoroutine("Type");
            cutsceneHasHappened = true;
        } else return;
    }
    
}
