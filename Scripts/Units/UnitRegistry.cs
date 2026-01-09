using System.Collections.Generic;
using UnityEngine;

public class UnitRegistry : MonoBehaviour
{
    public static UnitRegistry Instance;

    private readonly List<UnitController> teamA = new();
    private readonly List<UnitController> teamB = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // ---------- REGISTER ----------
    public void Register(UnitController unit)
    {
        if (unit == null) return;

        if (unit.CompareTag("TeamA"))
        {
            if (!teamA.Contains(unit))
                teamA.Add(unit);
        }
        else if (unit.CompareTag("TeamB"))
        {
            if (!teamB.Contains(unit))
                teamB.Add(unit);
        }
    }

    // ---------- UNREGISTER ----------
    public void Unregister(UnitController unit)
    {
        if (unit == null) return;

        teamA.Remove(unit);
        teamB.Remove(unit);
    }

    // ---------- ACCESS ----------
    public List<UnitController> GetEnemyList(string myTag)
    {
        return myTag == "TeamA" ? teamB : teamA;
    }

    public List<UnitController> GetFriendList(string myTag)
    {
        return myTag == "TeamA" ? teamA : teamB;
    }

    // ---------- HARD RESET (CRITICAL) ----------
    public void Clear()
    {
        // Destroy Team A
        for (int i = teamA.Count - 1; i >= 0; i--)
        {
            if (teamA[i] != null)
                Destroy(teamA[i].gameObject);
        }

        // Destroy Team B
        for (int i = teamB.Count - 1; i >= 0; i--)
        {
            if (teamB[i] != null)
                Destroy(teamB[i].gameObject);
        }

        teamA.Clear();
        teamB.Clear();
    }
}
