using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance;

    public MatchState CurrentState { get; private set; } = MatchState.Waiting;

    [Header("References")]
    public UnitSpawner unitSpawner;
    public EnemyWaveSpawner enemySpawner;
    public ResourceManager resourceManager;
    public BaseController playerBase;
    public BaseController enemyBase;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Called by UI Start Button
// Called by UI Start Button
public void StartGame()
{
    if (CurrentState != MatchState.Waiting)
        return;

    Debug.Log("▶ GAME STARTING");

    ResetMatch();
    ChangeState(MatchState.Playing);

    if (resourceManager != null)
        resourceManager.StartGeneration();

    if (enemySpawner != null)
        enemySpawner.StartSpawning();
}

public void WinGame()
{
    if (CurrentState != MatchState.Playing) return;

    ChangeState(MatchState.Won);

    if (enemySpawner != null)
        enemySpawner.StopSpawning();

    if (resourceManager != null)
        resourceManager.StopGeneration();

    Debug.Log("🎉 YOU WIN!");
}
    public void LoseGame()
    {
        if (CurrentState != MatchState.Playing) return;

        ChangeState(MatchState.Lost);
        if (enemySpawner != null)
            enemySpawner.StopSpawning();

                if (resourceManager != null)
        resourceManager.StopGeneration();

        Debug.Log("💀 YOU LOSE!");
    }

    // Called by UI Restart Button
    public void RestartGame()
    {
        Debug.Log("🔄 RESTARTING GAME");

        if (enemySpawner != null)
            enemySpawner.StopSpawning();

        // Reset everything
        ResetMatch();

        // Go back to waiting state
        ChangeState(MatchState.Waiting);

        Debug.Log("⏸ Game is now in Waiting state, press Start to play again.");
    }

    private void ResetMatch()
    {
        Debug.Log("♻ Resetting Match");

        if (enemySpawner != null)
            enemySpawner.ResetSpawner();

        if (unitSpawner != null)
            unitSpawner.ResetSpawner();

        if (resourceManager != null)
            resourceManager.ResetResources();

if (UnitRegistry.Instance != null)
    UnitRegistry.Instance.Clear();

        if (playerBase != null)
            playerBase.ResetBase();

        if (enemyBase != null)
            enemyBase.ResetBase();
    }

    private void ChangeState(MatchState newState)
    {
        Debug.Log($"STATE: {CurrentState} → {newState}");
        CurrentState = newState;
    }

    // TEMP keys for testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) WinGame();
        if (Input.GetKeyDown(KeyCode.L)) LoseGame();
        if (Input.GetKeyDown(KeyCode.R)) RestartGame();
    }
}
