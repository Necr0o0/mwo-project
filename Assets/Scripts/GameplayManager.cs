using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GridGenerator GridGenerator;
    public PlayerController PlayerModelPrefab;
    
    [HideInInspector]
    public PlayerController PlayerModel;
    public EnemyLogic enemyPrefab;
    
    public Graph grid;
    public GameManager gameManager;
    
    public static GameplayManager instance;
    
    public readonly List<EnemyLogic> enemyList = new List<EnemyLogic>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void StartGameplay(GameManager gm)
    {
        gameManager = gm;
        Debug.Log("So it begins!");
        grid = GridGenerator.Generate();
        
        enemyList.Clear();

        PlayerModel = Instantiate(PlayerModelPrefab, Vector3.up, Quaternion.identity);
        PlayerModel.MoveTo(grid.GetNode(3));
        
        SpawnEnemy(5);
    }
    
    public void GameOver()
    {
        gameManager.StartSummary(false);
    }

    private void SpawnEnemy(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Graph.Node node = grid.GetRandomFreeNode();

            var pos = node.worldPos;
            pos.y += 1.5f;
            var enemyInstance = Instantiate(enemyPrefab,pos , Quaternion.identity);
            
            enemyInstance.Spawn(node);
            
            enemyList.Add(enemyInstance);
        }
    }
    
    public bool CheckWinCondition()
    {
        if (enemyList.Count <= 0)
        {
            return true;
        }

        return false;
    }

    public void Move()
    {
        foreach (var enemy in enemyList)
        {
            enemy.Move();
        }
    }

}
