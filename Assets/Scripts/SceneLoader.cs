using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] private int sceneToLoad;

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
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
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
}

   
