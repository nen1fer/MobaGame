using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class UserInputListener : MonoBehaviour
    {
        public event Action<Vector2> onMovementInput;
        public event Action<Vector3> onDestinationChanged;
        public event Action<Unit> onUnitSelection;

        private readonly RaycastHit[] _raycastHits = new RaycastHit[5];
        private int _raycastArraySize;

        private void Update()
        {
            CheckAxis();
            CheckMouseClicks();
            CheckRaycasts();
        }

        private void CheckRaycasts()
        {
            Vector3? groundPosition = default;
            for (var i = 0; i < _raycastArraySize; i++)
            {
                var hit = _raycastHits[i];

                if (hit.collider.gameObject.TryGetComponent<Unit>(out var unit))
                {
                    onUnitSelection?.Invoke(unit);
                    return;
                }

                if (hit.collider.gameObject.TryGetComponent<Ground>(out var ground))
                    groundPosition = hit.point;
            }

            if (groundPosition.HasValue)
                onDestinationChanged?.Invoke(groundPosition.Value);
        }

        private void CheckMouseClicks()
        {
            _raycastArraySize = 0;
            if (!Input.GetMouseButtonDown(0))
                return;

            var mousePos = Input.mousePosition;
            var ray = Camera.main.ScreenPointToRay(mousePos);
            _raycastArraySize = Physics.RaycastNonAlloc(ray, _raycastHits, 999);
        }

        private void CheckAxis()
        {
            var hor = Input.GetAxis("Horizantal");
            var vert = Input.GetAxis("Vertical");

            if (hor != 0 || vert != 0)
                onMovementInput?.Invoke(new Vector2(hor, vert));
        }
    }

}
