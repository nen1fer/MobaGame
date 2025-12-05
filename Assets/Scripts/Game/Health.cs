using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;

        public event Action onDie;
        public Action<int> onChanged;

        private bool _dying;

        public void Initialize()
        {
            _currentHealth = _maxHealth;
        }

        private void SetHealth(int value)
        {
            if (_dying)
                return;

            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
            onChanged?.Invoke(_currentHealth);
            if (_currentHealth == 0)
                Die();
        }

        private void Die()
        {
            _dying = true;
            onDie?.Invoke();
        }

        public void Damage(int decrease) => SetHealth(_currentHealth - decrease);
        public void Heal(int increase) => SetHealth(_currentHealth + increase);
        public int GetCurrent() => _currentHealth;
        public int GetMax() => _maxHealth;
    }

}
