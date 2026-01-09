using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    private float currentMultiplier = 1f;
    private string currentPhase = "EARLY";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // ✅ Public getter for ResourceManager or other scripts
    public float GetMultiplier()
    {
        return currentMultiplier;
    }

    public string CurrentPhase => currentPhase;

    // Example: call this every frame or via timer
    private void Update()
    {
        UpdateDifficulty();
    }
public float GetNormalizedTime()
{
    float totalDuration = 300f; // 5 minutes, adjust as needed
    return Mathf.Clamp01(Time.time / totalDuration);
}

    private void UpdateDifficulty()
    {
        float time = Time.time;
        string newPhase;
        float newMultiplier;

        if (time < 60f)
        {
            newPhase = "EARLY";
            newMultiplier = 1f;
        }
        else if (time < 180f)
        {
            newPhase = "MID";
            newMultiplier = 1.5f;
        }
        else
        {
            newPhase = "LATE";
            newMultiplier = 2f;
        }

        if (newPhase != currentPhase)
        {
            currentPhase = newPhase;
            currentMultiplier = newMultiplier;

            Debug.Log($"[Difficulty] Phase: {currentPhase}, Multiplier: x{currentMultiplier}");
        }
    }
}
