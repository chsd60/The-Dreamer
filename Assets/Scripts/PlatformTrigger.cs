using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformTrigger : MonoBehaviour {

    public UnityEvent enterAction;
    public UnityEvent exitAction;
    private void OnTriggerEnter2D(Collider2D collision) {
        enterAction.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        exitAction.Invoke();
    }
}
