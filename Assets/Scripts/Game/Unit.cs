using UnityEngine;

namespace Assets.Scripts.Game
{

    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(TeamTag))]

    [SelectionBase]
    public class Unit : MonoBehaviour
    {
        protected Health _health;
        protected TeamTag _team;

        protected virtual void Awake()
        {
            _health = GetComponent<Health>();
            _team = GetComponent<TeamTag>();
        }

        public virtual void Initialize()
        {
            _health.Initialize();
            _health.onDie += Die;
            GamePlayManager.Instance.Register(this);
        }

        private void Die()
        {
            GamePlayManager.Instance.Unregister(this);
            Destroy(gameObject, .1f);
        }

        public TeamTag GetTeam() => _team;
        public Health GetHealth() => _health;
        public Vector3 Position => transform.position;
    }

}
