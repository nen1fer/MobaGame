using Assets.Scripts.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class UnitBar : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _healthBar;
        [SerializeField] private Gradient _gradient;
        private Health _health;

        public void Set(Unit unit)
        {
            _name.text = unit.GetName();
            _health = unit.GetHealth();
            _health.onChanged += UpdateValue;
            UpdateValue(_health.GetCurrent());
        }

        private void UpdateValue(int obj)
        {
            float value = 0;
            if (obj > 0)
                value = (float)obj / _health.GetMax();
            value = Mathf.Clamp01(value);
            _healthBar.fillAmount = value;
            _healthBar.color = _gradient.Evaluate(value);
        }

        private void OnDestroy()
        {
            if (!_health.IsNullOrDefault())
                _health.onChanged -= UpdateValue;
        }
    }
}
