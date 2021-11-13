using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GridGenerator GridGenerator;
    public GridGenerator PlayerModel;

    private Vector2Int grid;
    private Vector2Int PlayerPos;

    
     public void StartGameplay()
    {
        Debug.Log("So it begins!");
        grid =  GridGenerator.Generate();
        
    }
    
}
