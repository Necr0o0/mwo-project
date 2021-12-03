using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Im going to Attack");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
    }
    

    public override void OnCollisionEnter(EnemyStateManager enemy)
    {
    }

}
