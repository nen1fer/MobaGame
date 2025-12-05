using UnityEngine;

namespace Assets.Scripts.Game
{
    public class CripFactory : MonoBehaviour
    {
        [SerializeField] private Crip _prefab;
        [SerializeField] private TeamTag _teamTag;
        [SerializeField] private float _timeDelay;
        [SerializeField] private int _amount;

        private float _currentDelay = 0;

        private void Update()
        {
            if (_currentDelay > 0)
            {
                _currentDelay -= Time.deltaTime;
                return;
            }

            _currentDelay = _timeDelay;
            for (var i = 0; i < _amount; i++)
            {
                var crip = Instantiate(_prefab, transform);
                crip.gameObject.SetActive(true);
                crip.GetTeam().SetTeamId(_teamTag.GetTeamId());
                crip.Initialize();
            }
        }
    }

}
