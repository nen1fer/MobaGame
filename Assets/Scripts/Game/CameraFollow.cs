using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector2 _zoomLimit = new Vector2(.5f, 5f);

        private static Vector3? _diff;

        private Camera _camera;
        private float _zoom = 1;

        private void OnEnable()
        {
            _camera = Camera.main;
            if (!_diff.HasValue)
                _diff = _camera.transform.position - transform.position;
        }

        private void Update()
        {
            var diff = Input.GetAxis("Mouse ScrollWheel");
            if (diff != 0)
            {
                _zoom = Mathf.Clamp(_zoom - diff, _zoomLimit.x, _zoomLimit.y);
                Debug.Log($"Camera zoom: {_zoom}");
            }

            _camera.transform.position = transform.position + _diff.Value * _zoom;
        }
    }
}
