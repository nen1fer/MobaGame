using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CharacterFactory : MonoBehaviour
    {
        [SerializeField] private Unit _prefab;
        [SerializeField] private TeamTag _teamTag;

        private Unit _current;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (!_current.IsNullOrDefault() && !_current.GetHealth().IsNullOrDefault())
                _current.GetHealth().onDie -= Spawn;
            var character = Instantiate(_prefab, transform);
            character.gameObject.SetActive(true);
            character.GetTeam().SetTeamId(_teamTag.GetTeamId());
            character.GetHealth().onDie += Spawn;
            character.Initialize();
        }
    }
}