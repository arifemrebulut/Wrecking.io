using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : IState
{
    private float _wanderSpeed;
    private float _rotationSpeed;
    private Rigidbody _rigidbody;

    private GameManager _gameManager;
    private AIStateMachine _stateMachine;

    private Ray ray;
    private Vector3 targetPoint;

    public WanderState(AIStateMachine stateMachine, GameManager gameManager, Rigidbody rigidbody,
        float forwardSpeed, float rotationSpeed)
    {
        _stateMachine = stateMachine;
        _gameManager = gameManager;
        _rigidbody = rigidbody;
        _wanderSpeed = forwardSpeed;
        _rotationSpeed = rotationSpeed;
    }

    public void Enter()
    {
        FindNewTargetPoint();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedTick()
    {
        float distanceFromTarget = Vector3.Distance(targetPoint, _rigidbody.position);

        if (distanceFromTarget < .3f)
        {
            FindNewTargetPoint();
        }

        else
        {
            RotateTowardsTarget();
            MoveTowardsTarget();
        }
    }

    public void Tick()
    {
        //CheckChaseDistance();
    }

    private void FindNewTargetPoint()
    {
        float unitRange = 0f;

        switch (_gameManager.sectionNumber)
        {
            case 5:
                unitRange = _gameManager.section5Range;
                break;
            case 4:
                unitRange = _gameManager.section4Range;
                break;
            case 3:
                unitRange = _gameManager.section3Range;
                break;
            case 2:
                unitRange = _gameManager.section2Range;
                break;
            case 1:
                unitRange = _gameManager.section1Range;
                break;
            case 0:
                unitRange = _gameManager.centerRange;
                break;
            default:
                unitRange = 10;
                break;
        }

        Vector2 randomPoint = Random.insideUnitCircle * unitRange;
        targetPoint = new Vector3(randomPoint.x, _stateMachine.transform.position.y, randomPoint.y);

        Debug.Log(targetPoint);
    }

    private void CheckChaseDistance()
    {
        if (Physics.SphereCast(ray, _stateMachine.chaseDistance, _stateMachine.aiLayerMask))
        {
            _stateMachine.ChangeState(_stateMachine.ChaseState);
        }
    }

    private void RotateTowardsTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(targetPoint - _rigidbody.position);
        lookRotation = Quaternion.Slerp(_rigidbody.rotation, lookRotation, _rotationSpeed * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(lookRotation);
    }

    private void MoveTowardsTarget()
    {
        Vector3 moveOffset = _stateMachine.transform.forward * (_wanderSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + moveOffset);
    }
}
