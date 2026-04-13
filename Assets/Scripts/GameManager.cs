using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int remainingTargets;
    int score; 
    [SerializeField] GameObject Win;

    void Start()
    {
        remainingTargets = FindObjectsOfType<TargetInteractables>().Length;
        Win.SetActive(false);
        Debug.Log("Targets remaining = " + remainingTargets);
    }

    public void TargetCollected()
    {
        remainingTargets -= 1;
        score += 1;
        Debug.Log("Targets remaining = " + remainingTargets);
        Debug.Log("Picked up! Score = " + score);

        if (remainingTargets <= 0)
        {
            Debug.Log("ALL TARGETS COLLECTED! Level Complete!");
            // put win UI / next level code here
        }
        if (score >= 5)
        {
            Debug.Log("Win Condition met!");
            Win.SetActive(true);
        }
    }
}
