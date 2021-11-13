using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> GameUI;

    [SerializeField] private GameplayManager gameplayManager;
    void Start()
    {
        
    }


    public void StartGameplay()
    {
        GameUI[0].SetActive(false);
        GameUI[1].SetActive(true);
        gameplayManager.StartGameplay();
        
    }
}
