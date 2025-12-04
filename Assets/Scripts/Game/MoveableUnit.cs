using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class MoveableUnit : Unit
{
    protected NavMeshAgent _navMeshAgent;
    protected override void Awake()
    {
        base.Awake();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    protected void SetStopDistance(float distance) => _navMeshAgent.stoppingDistance = distance;
    protected virtual void SetDestination(Vector3 direction) => _navMeshAgent.SetDestination(direction);
}


