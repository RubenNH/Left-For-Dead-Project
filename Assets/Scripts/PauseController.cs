using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    public GunScript gunScript;
    public MouseLookScript mouseLookScript;
    public PlayerMovementScript playerMovementScript;
    // Reference to the GameObject controlling the player's weapons
    public GameObject playerController; // Assign this in the Unity Editor or dynamically

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pause the game physics
        if (playerController != null)
        {
            gunScript.enabled = false;
            mouseLookScript.enabled = false;
            playerMovementScript.enabled = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game physics
        if (playerController != null)
        {
            gunScript.enabled = true;
            mouseLookScript.enabled = true;
            playerMovementScript.enabled = true;
        }

        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu"); // Replace with your menu scene name
    }
}