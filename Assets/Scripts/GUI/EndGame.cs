using Assets.Scripts.Game;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private GameObject _win;
        [SerializeField] private GameObject _lose;

        private int? _teamId;

        private void Start()
        {
            _win.gameObject.SetActive(false);
            _lose.gameObject.SetActive(false);
            Session.Instance.GamePlayManager.onRemoved += UnitDie;
        }

        private void OnDestroy()
        {
            Session.Instance.GamePlayManager.onRemoved -= UnitDie;
            Time.timeScale = 1;
        }

        private void UnitDie(Unit obj)
        {
            if (!(obj is Base building))
                return;

            CheckPlayerTeam();

            if (building.GetTeam().GetTeamId() == _teamId.Value)
                Lose();
            else
                Win();
        }

        private void CheckPlayerTeam()
        {
            if (_teamId.HasValue)
                return;

            var player = Session.Instance.GamePlayManager.Find<Player>(u => true)[0];
            _teamId = player.GetTeam().GetTeamId();
        }

        private void SetWindowActive(GameObject window)
        {
            Time.timeScale = 0;
            window.gameObject.SetActive(true);
        }

        private void Lose() => SetWindowActive(_lose);
        private void Win() => SetWindowActive(_win);
    }
}