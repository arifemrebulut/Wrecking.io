using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    public IState previousState;

    private bool inTransition;

    public void ChangeState(IState newState)
    {
        if (CurrentState == newState || inTransition)
        {
            return;
        }

        ChangeStateTransition(newState);
    }

    public void RevertState()
    {
        if (previousState != null)
        {
            ChangeState(previousState);
        }
    }

    private void ChangeStateTransition(IState newState)
    {
        inTransition = true;

        if (CurrentState != null)
            CurrentState.Exit();

        if (previousState != null)
            previousState = CurrentState;

        CurrentState = newState;

        if (CurrentState != null)
            CurrentState.Enter();

        inTransition = false;
    }

    public void Update()
    {
        if (CurrentState != null && !inTransition)
            CurrentState.Tick();
    }

    private void FixedUpdate()
    {
        if (CurrentState != null && !inTransition)
            CurrentState.FixedTick();
    }
}
