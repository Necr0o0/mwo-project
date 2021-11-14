using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    private Vector3 randomMove;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Im going to Move");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
      
        randomMove.x = Random.Range(-2f, 2f);
        randomMove.z = Random.Range(-2f, 2f);

        enemy.transform.position += randomMove * Time.deltaTime;
    }
    

    public override void OnCollisionEnter(EnemyStateManager enemy)
    {
        throw new System.NotImplementedException();
    }

}
