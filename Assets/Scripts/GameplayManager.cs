using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GridGenerator GridGenerator;
    public PlayerController PlayerModel;

    public Graph grid;

    public static GameplayManager instance;

    private void Awake()
    {
        if(instance== null)
            instance = this;
    }


    public void StartGameplay()
    {
        Debug.Log("So it begins!");

        Debug.Log("So it begins!");
        grid =  GridGenerator.Generate();
        Instantiate(PlayerModel, Vector3.up, Quaternion.identity);
        PlayerModel.MoveTo(grid.Nodes[3]);
    }

    
}
