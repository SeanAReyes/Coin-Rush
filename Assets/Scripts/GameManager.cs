using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int remainingTargets;
    int score; 
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject gameoverScreen;

    void Start()
    {
        remainingTargets = FindObjectsOfType<TargetInteractables>().Length;
        winScreen.SetActive(false);
        gameoverScreen.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Targets remaining = " + remainingTargets);
    }

    public void TargetCollected()
    {
        remainingTargets -= 1;
        score += 1;
        Debug.Log("Targets remaining = " + remainingTargets);
        

        if (remainingTargets <= 0)
        {
            Debug.Log("ALL TARGETS COLLECTED! Loading next level!");
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextScene < SceneManager.sceneCountInBuildSettings)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                //no more levels, show win screen
                winScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }

    }

    public void GameOver()
    {
        Debug.Log("GAME OVER! Try again!");
        gameoverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
