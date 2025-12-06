using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(WeaponHandler))]
    public abstract class MoveableUnit : Unit
    {
        protected NavMeshAgent _navMeshAgent;
        protected WeaponHandler _weaponHandler;
        protected override void Awake()
        {
            base.Awake();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _weaponHandler = GetComponent<WeaponHandler>();
        }

        public override void Initialize()
        {
            base.Initialize();
            SetStopDistance(GetAttackRange());
        }

        protected float GetAttackRange() => _weaponHandler.GetWeapon().GetAttackRange() - 1f;
        protected void SetStopDistance(float distance) => _navMeshAgent.stoppingDistance = distance;
        protected virtual void SetDestination(Vector3 direction) => _navMeshAgent.SetDestination(direction);
    }
}
