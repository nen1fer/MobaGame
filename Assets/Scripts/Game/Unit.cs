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
            Session.Instance.GamePlayManager.Register(this);
        }

        private void Die()
        {
            Session.Instance.GamePlayManager.Unregister(this);
            Destroy(gameObject, .1f);
        }

        public TeamTag GetTeam() => _team;
        public Health GetHealth() => _health;
        public string GetName() => gameObject.name.Substring(0, gameObject.name.IndexOf("("));
        public Vector3 Position => transform.position;
    }

}
