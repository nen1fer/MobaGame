using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Player : Character
    {
        private UserInputListener _userInput;
        private SelectionTargetController _targetController;
        private Unit _target;

        protected override void Awake()
        {
            base.Awake();
            _targetController = GetComponent<SelectionTargetController>();
            _targetController.onTargetChanged += ChangeTarget;
            _userInput = GetComponent<UserInputListener>();
            _userInput.onUnitSelection += _targetController.TrySelectTarget;
            _userInput.onDestinationChanged += InputDestination;
            _userInput.onMovementInput += Movement;
        }

        private void InputDestination(Vector3 obj)
        {

        }

        private void ChangeTarget(Unit obj)
        {

        }

        private void Movement(Vector2 obj)
        {

        }

        private void ResetTarget()
        {

        }

        private void Update()
        {
            if (!_target.IsNullOrDefault())
            {
                SetDestination(_target.Position);
                transform.LookAt(_target.Position);
            }
        }

        public UserInputListener GetInputListener() => _userInput;
        public SelectionTargetController GetTargetController() => _targetController;
    }

}
