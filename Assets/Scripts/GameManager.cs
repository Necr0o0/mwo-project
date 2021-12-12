using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameUI;

    [SerializeField] private GameplayManager gameplayManager;
    [SerializeField] private SummaryWindow summaryWindow;

    [Space]
    [Min(1)]
    [SerializeField] private int pointsPerRound = 2;
    

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
        gameplayManager.StartGameplay(this);
        StartPlayerTurn();
    }
    
    
    public void StartSummary(bool won)
    {
        summaryWindow.ShowEndScreen(won);
        gameUI[1].SetActive(false);
        gameUI[2].SetActive(true);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
        /*gameUI[2].SetActive(false);
        gameUI[0].SetActive(true);*/
    }

    public void EndTurn()
    {
        UIActionsManager.SetActiveGameplayActions(false);

        if (gameplayManager.CheckWinCondition())
        {
            StartSummary(true);
            return;
        }
        gameplayManager.Move();
        
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        UIActionsManager.SetPoints(pointsPerRound);
        UIMovementControl.instance?.RefreshInputVisual();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
