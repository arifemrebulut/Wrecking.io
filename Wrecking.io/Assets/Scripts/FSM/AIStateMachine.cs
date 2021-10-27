using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : BaseStateMachine
{
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float rotationSpeed;

    public Rigidbody rigidbody;
    public LayerMask aiLayerMask;
    public float chaseDistance;
    public float attackDistance;

    public WanderState WanderState { get; private set; }
    public ChaseState ChaseState { get; private set; }
    public AttackState AttackState { get; private set; }

    public GameManager GameManager;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();

        WanderState = new WanderState(this, GameManager, rigidbody, wanderSpeed, rotationSpeed);
        ChaseState = new ChaseState(this, rigidbody, chaseSpeed);
        AttackState = new AttackState(this, rigidbody);
    }

    void Start()
    {
        ChangeState(WanderState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
