
using System;
using Enemy;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private EnemyData EnemyData;

    public int gridPos;
    private Graph grid;

    private Graph.Node currentNode;

    

    public void Spawn(int startID)
    {
        gridPos = startID;
      // currentNode = grid.Nodes[gridPos];
      grid = GameplayManager.instance.grid;
      
      //grid.Nodes[gridPos].SetOccupied(true);

      EnemyData = new EnemyData();
    }

    private void Attack()
    {
        
    }
    
    public void Move()
    {
        var path =  grid.GetPath(grid.Nodes[gridPos], GameplayManager.instance.PlayerModel.GetNodePosition());

        if (path.Count > 1)
        {
            var pos = path[1].worldPos;
            pos.y += 1.5f;
            transform.position = pos;
            
          //  grid.Nodes[gridPos].SetOccupied(false);
            gridPos = path[1].index;
           // grid.Nodes[gridPos].SetOccupied(true);

        }

    }
}
