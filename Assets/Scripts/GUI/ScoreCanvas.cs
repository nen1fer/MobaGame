using System;
using System.Collections.Generic;
using Assets.Scripts.Game;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    [RequireComponent(typeof(RectTransform))]
    public class ScoreCanvas : MonoBehaviour
    {
        [SerializeField] private TMP_Text _battleTime;
        [SerializeField] private string _battleTimeFormat;

        [SerializeField] private TMP_Text _killsTeam1;
        [SerializeField] private string _killsTeam1Format;
        [SerializeField] private TMP_Text _killsTeam2;
        [SerializeField] private string _killsTeam2Format;

        private readonly Dictionary<int, int> _deaths = new Dictionary<int, int>
        {
            {1, 0},
            {2, 0}
        };

        private void Start()
        {
            Session.Instance.GamePlayManager.onRemoved += OnUnitRemoved;
        }

        private void OnDestroy()
        {
            Session.Instance.GamePlayManager.onRemoved -= OnUnitRemoved;
        }

        private void Update()
        {
            var time = TimeSpan.FromSeconds(Session.Instance.GamePlayManager.GetBattleTime());
            _battleTime.text = string.Format(_battleTimeFormat, time);

            int killsTeam1 = _deaths[2];
            int killsTeam2 = _deaths[1];

            _killsTeam1.text = string.Format(_killsTeam1Format, killsTeam1.ToString());
            _killsTeam2.text = string.Format(_killsTeam2Format, killsTeam2.ToString());
        }

        private void OnUnitRemoved(Unit unit)
        {
            int teamId = unit.GetTeam().GetTeamId();
            if (_deaths.ContainsKey(teamId))
            {
                _deaths[teamId]++;
            }
        }
    }
}