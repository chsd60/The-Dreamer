using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    // isDead probabilmente è inutile, ma l'ho messo per far da flag
    public bool isDead = false;
    // Respawn = Numero di scena corrente
    public int Respawn;

    // Se il giocatore tocca il nemico, flag isDead = True, parte la coroutine
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isDead = true;
            StartCoroutine(DeadPlayer());
        }
    }

    // Disattiva il game object del giocatore, e dopo due secondi ricarica la scena.
    // Probabilmente andrà cambiato.
    IEnumerator DeadPlayer() {
        if (isDead == true) {
            GameObject.Find("Player").SetActive(false);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(Respawn);
        }
    }
}
