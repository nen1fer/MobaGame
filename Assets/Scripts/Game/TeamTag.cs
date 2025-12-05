using UnityEngine;

namespace Assets.Scripts.Game
{
    public class TeamTag : MonoBehaviour
    {
        [SerializeField, Range(1, 2)] private int _teamId;

        public void SetTeamId(int value) => _teamId = value;
        public int GetTeamId() => _teamId;
    }

}
