using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [Serializable]
    public class Weapon
    {
        [SerializeField] private float _attackRange;
        [SerializeField] private int _damageValue;
        [SerializeField] private float _attackInterval;

        public float GetAttackRange() => _attackRange;
        public int GetDamageValue() => _damageValue;
        public float GetAttackInterval() => _attackInterval;
    }

}
