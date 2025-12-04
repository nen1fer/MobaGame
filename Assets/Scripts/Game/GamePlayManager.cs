using System;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private int _amountTeams = 2;
    [SerializeField] private List<Material> _teamMaterials = new List<Material>();
    [SerializeField] private List<Unit> _allUnits = new List<Unit>();

    public event Action<Unit> onAdded;
    public event Action<Unit> onRemoved;

    private float _currentDelay;
    private float _delay = 1f;
    private float _battleTime;

    private void Awake()
    {
        Game.Instance.GamePlayManager = this;
        _battleTime = 0;
    }

    private void Update()
    {
        _battleTime += Time.deltaTime;
        if (_currentDelay > 0)
        {
            _currentDelay -= Time.deltaTime;
            return;
        }

        _currentDelay = _delay;
        CheckInterceptions();
    }

    public List<T> Find<T>(Func<T, bool> predicate) where T : Unit
    {
        var result = new List<T>();
        foreach (var unit in _allUnits)
        {
            if (unit is T t)
                if (predicate(t))
                    result.Add(t);
        }

        return result;
    }

    public void Register(Unit unit)
    {
        Debug.Log($"{GetType()}::Register unit{unit.GetName()}");
        _allUnits.Add(unit);
        onAdded?.Invoke(unit);
    }

    public void Unregister(Unit unit)
    {
        Debug.Log($"{GetType()}::Unregister unit{unit.GetName()}");
        _allUnits.Remove(unit);
        onRemoved?.Invoke(unit);
    }

    private void CheckInterceptions()
    {
        var potentialTargets = new List<Unit>(10);
        for (var i = 1; i <= _amountTeams; i++)
        {
            var units = GetAllAllies(i);
            var enemies = GetAllEnemies(i);
            foreach (var unit in units)
            {
                if (unit is INeedTarget attacker)
                {
                    potentialTargets.Clear();
                    var viewDistance = attacker.GetViewDistance();
                    foreach (var enemy in enemies)
                    {
                        if (Vector3.Distance(enemy.Position, unit.Position) <= viewDistance)
                            potentialTargets.Add(enemy);
                    }

                    attacker.SetPotentialTargets(potentialTargets);
                }
            }
        }
    }

    public List<Base> GetEnemiesBases(TeamTag team) => Find<Base>(u => u.GetTeam().GetTeamId() != team.GetTeamId());
    public List<Unit> GetAllEnemies(TeamTag team) => Find<Unit>(u => u.GetTeam().GetTeamId() != team.GetTeamId());
    public List<Unit> GetAllAllies(TeamTag team) => Find<Unit>(u => u.GetTeam().GetTeamId() == team.GetTeamId());
    private List<Base> GetEnemiesBases(int teamId) => Find<Base>(u => u.GetTeam().GetTeamId() != teamId);
    private List<Unit> GetAllEnemies(int teamId) => Find<Unit>(u => u.GetTeam().GetTeamId() != teamId);
    private List<Unit> GetAllAllies(int teamId) => Find<Unit>(u => u.GetTeam().GetTeamId() == teamId);
    public Material GetMyTeamColor(TeamTag team) => _teamMaterials[team.GetTeamId() - 1];
    public IReadOnlyCollection<Unit> GetAllUnits() => _allUnits;
    public float GetBattleTime() => _battleTime;
}
