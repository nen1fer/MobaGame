using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Crip : MoveableUnit, INeedTarget
    {
        private AutoTargetController _targetController;
        private Unit _target;
        private void Start()
        {
            base.Awake();
            _targetController = GetComponent<AutoTargetController>();
        }

        public override void Initialize()
        {
            base.Initialize();

            _targetController.onTargetChanged += SetTarget;

            var bases = GamePlayManager.Instance.GetEnemiesBases(_team);
            SetDestination(bases[0].Position);
        }

        private void OnDestroy()
        {
            _targetController.onTargetChanged -= SetTarget;
        }


        private void Update()
        {
            if (_target.IsNullOrDefault())
                SetDestination(_target.Position);
        }
        public void SetPotentialTargets(List<Unit> potentialTargets) => _targetController.SetPotentialTargets(potentialTargets);
        public float GetViewDistance() => _targetController.GetViewDistance();

        public void SetTarget(Unit unit) => _target = unit;
    }
}
