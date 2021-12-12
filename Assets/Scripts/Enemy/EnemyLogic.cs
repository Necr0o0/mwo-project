using UnityEngine;

public class EnemyLogic : MonoBehaviour, IEntity
{
    private Graph grid;

    private Graph.Node currentNode;

    public void Spawn(Graph.Node startNode)
    {
        grid = GameplayManager.instance.grid;
        currentNode = startNode;
        currentNode.Occupy(this);
    }

    public void Move()
    {
        currentNode.Free();

        var path =  grid.GetPath(currentNode, GameplayManager.instance.PlayerModel.GetNodePosition());

        if (path.Count > 1)
        {
            var pos = path[1].worldPos;
            pos.y += 1.5f;
            transform.position = pos;
            
            currentNode = path[1];
            if (currentNode == GameplayManager.instance.PlayerModel.GetNodePosition())
                GameplayManager.instance.PlayerModel.OnAttacked();
            currentNode.Occupy(this);
        }
    }

    public void OnAttacked()
    {
        GameplayManager.instance.enemyList.Remove(this);
        currentNode.Free();
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        currentNode.Free();
        var path =  grid.GetPath(currentNode, GameplayManager.instance.PlayerModel.GetNodePosition());
        currentNode.Occupy(this);

        if (path.Count > 0 && path.Count <= 3)
        {
            bool successfulAttack = UIActionsManager.MakeAction(KillTutorial.KillPointsCost);
            if (successfulAttack)
                OnAttacked();
        }
    }
}
