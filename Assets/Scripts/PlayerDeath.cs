using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    public bool isDead = false;
    public int Respawn;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isDead = true;
            StartCoroutine(DeadPlayer());
        }
    }

    IEnumerator DeadPlayer() {
        if (isDead == true) {
            GameObject.Find("Player").SetActive(false);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(Respawn);
        }
    }
}
