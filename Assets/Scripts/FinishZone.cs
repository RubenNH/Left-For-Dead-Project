using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
            Debug.Log("Game Finished!");
            EndGame();
        }
    }

    void EndGame() {
        SceneManager.LoadScene("WINSCENE"); // Replace with your win scene name
    }
}
