using UnityEngine;
public enum MatchState
{
    Waiting,   // before Start button
    Playing,
    Won,
    Lost
}

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public MatchState CurrentState = MatchState.Waiting;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Called by Start Button
public EnemyWaveSpawner enemySpawner;

public void StartGame()
{
    CurrentState = MatchState.Playing;
    Debug.Log("▶ GAME STARTED");

    if (enemySpawner != null)
    {
        enemySpawner.SpawnEnemy();
    }
    else
    {
        Debug.LogError("EnemyWaveSpawner not assigned in MatchManager!");
    }
}


    public void WinGame()
    {
        if (CurrentState != MatchState.Playing) return;

        CurrentState = MatchState.Won;
        Debug.Log("🎉 YOU WIN!");
    }

    public void LoseGame()
    {
        if (CurrentState != MatchState.Playing) return;

        CurrentState = MatchState.Lost;
        Debug.Log("💀 YOU LOSE!");
    }
}
