using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(AutoTargetController))]
    public class AIUnit : Character, INeedTarget
    {
        private AutoTargetController _targetController;
        private Unit _target;

        protected override void Awake()
        {
            base.Awake();
            _targetController = GetComponent<AutoTargetController>();
        }

        public override void Initialize()
        {
            base.Initialize();
            _targetController.onTargetChanged += SetTarget;
        }
        private void Update()
        {
            if (!_target.IsNullOrDefault())
                SetDestination(_target.Position);
        }

        private void SetTarget(Unit unit) => _target = unit;
        public float GetViewDistance() => _targetController.GetViewDistance();
        public void SetPotentialTargets(List<Unit> potentialTargets) => _targetController.SetPotentialTargets(potentialTargets);
    }

}
