using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Game;

namespace Assets.Scripts.GUI
{
    [RequireComponent(typeof(RectTransform))]
    public class UnitCanvas : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private UnitBar _bar;

        private readonly Dictionary<Unit, UnitBar> _units = new Dictionary<Unit, UnitBar>();

        private void Start()
        {
            Session.Instance.GamePlayManager.onAdded += Add;
            Session.Instance.GamePlayManager.onRemoved += Remove;
            foreach (var unit in Session.Instance.GamePlayManager.GetAllUnits())
                _units.Add(unit, CreateBar(unit));
        }

        private void OnDestroy()
        {
            Session.Instance.GamePlayManager.onAdded -= Add;
            Session.Instance.GamePlayManager.onRemoved -= Remove;
        }

        private void Update()
        {
            foreach (var unit in _units) 
                unit.Value.transform.position = _camera.WorldToScreenPoint(unit.Key.Position + Vector3.up * 2);
        }

        private void Remove(Unit unit)
        {
            Destroy(_units[unit].gameObject);
            _units.Remove(unit);
        }

        private UnitBar CreateBar(Unit unit)
        {
            var instance = Instantiate(_bar, transform);
            instance.Set(unit);
            instance.gameObject.SetActive(true);
            return instance;
        }

        private void Add(Unit unit) => _units.Add(unit, CreateBar(unit));
    }
}
