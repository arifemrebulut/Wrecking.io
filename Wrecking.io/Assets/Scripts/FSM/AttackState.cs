using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    private Rigidbody _rigidbody;
    private AIStateMachine _stateMachine;

    private Ray ray;

    public AttackState(AIStateMachine stateMachine, Rigidbody rigidbody)
    {
        _stateMachine = stateMachine;
        _rigidbody = rigidbody;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedTick()
    {
        throw new System.NotImplementedException();
    }

    public void Tick()
    {
        CheckEnemyInRange();
    }

    private void CheckEnemyInRange()
    {
        if (!Physics.SphereCast(ray, _stateMachine.attackDistance, _stateMachine.aiLayerMask))
        {
            _stateMachine.ChangeState(_stateMachine.WanderState);
        }
    }
}
