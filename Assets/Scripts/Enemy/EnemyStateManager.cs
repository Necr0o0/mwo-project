using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
     EnemyBaseState currentState;
    
     EnemyAttackState  AttackState = new EnemyAttackState();
     EnemyMoveState  MoveState = new EnemyMoveState();

    
    // Start is called before the first frame update
    void Start()
    {
        currentState = MoveState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
         currentState.UpdateState(this);   
    }

    private void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this);
    }

    void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
