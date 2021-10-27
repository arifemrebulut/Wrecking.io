using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IState
{
    private float _chaseSpeed;
    private Rigidbody _rigidbody;
    private AIStateMachine _stateMachine;

    private Ray ray;

    public ChaseState(AIStateMachine stateMachine, Rigidbody rigidbody, float chaseSpeed)
    {
        _stateMachine = stateMachine;
        _rigidbody = rigidbody;
        _chaseSpeed = chaseSpeed;
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
        CheckAttackDistance();
    }

    private void CheckAttackDistance()
    {
        if (Physics.SphereCast(ray, _stateMachine.attackDistance, _stateMachine.aiLayerMask))
        {
            _stateMachine.ChangeState(_stateMachine.AttackState);
        }
    }
}
