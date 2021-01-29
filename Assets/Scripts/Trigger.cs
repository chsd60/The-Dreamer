using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    public UnityEvent enterAction;
    public UnityEvent exitAction;
    public UnityEvent stayAction;

    private void OnTriggerEnter2D(Collider2D collision) {
        enterAction.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetButtonDown("Down")) {
            stayAction.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        exitAction.Invoke();
    }
}
