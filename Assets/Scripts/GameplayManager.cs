using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GridGenerator GridGenerator;
    public PlayerController PlayerModel;

    public EnemyLogic enemy;


    private List<EnemyLogic> enemyList;
    
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
        grid =  GridGenerator.Generate();
        
        enemyList = new List<EnemyLogic>();

        Instantiate(PlayerModel, Vector3.up, Quaternion.identity);
        PlayerModel.MoveTo(grid.Nodes[3]);
        
        SpawnEnemy(3);
    }
    
    public void GameOver()
    {
        Debug.Log("So it ends!");

    }

    public void SpawnEnemy(int spawncount)
    {
        for (int i = 0; i < spawncount; i++)
        {
            var spawnPos =   grid.GetRandomNodeID();
            var pos = grid.Nodes[spawnPos].worldPos;
            pos.y += 1.5f;
            var enemyInstance = Instantiate(enemy,pos , Quaternion.identity);
            
            enemyInstance.Spawn(spawnPos);
            
            enemyList.Add(enemyInstance);
        }
    }

    public void Move()
    {
        foreach (var enemy in enemyList)
        {
            enemy.Move();
        }
    }

}
