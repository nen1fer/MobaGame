using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [Serializable]
    public struct AttackPriority
    {
        public string Enemy;
        [Tooltip("Первым выбирается с наибольшим"), Range(0, 99)] public int Priority;

        public AttackPriority(Type type, int priority)
        {
            Enemy = type.FullName;
            Priority = priority;
        }
        public Type EnemyType => Type.GetType(Enemy);
    }


}
