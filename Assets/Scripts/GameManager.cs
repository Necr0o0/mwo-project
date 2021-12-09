using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameUI;

    [SerializeField] private GameplayManager gameplayManager;

    private void Awake()
    {
        gameUI[0].SetActive(true);
        for (int i = 1; i < gameUI.Count; i++)
        {
            gameUI[i].SetActive(false);
        }
    }

    public void StartGameplay()
    {
        gameUI[0].SetActive(false);
        gameUI[1].SetActive(true);
        gameplayManager.StartGameplay();
        StartPlayerTurn();
    }

    public void EndTurn()
    {
        UIActionsManager.SetActiveGameplayActions(false);
        
        gameplayManager.Move();
        
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        UIActionsManager.SetPoints(2);
    }
}
