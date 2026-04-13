using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInteractables : MonoBehaviour
{
   
    public enum InteractableType
    {
        Collectable,
        Restart
    }
    public InteractableType type;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Trigger()
    {
        if (type == InteractableType.Collectable)
        {
            gameManager.TargetCollected();
        }
        gameObject.SetActive(false);
    }

}
