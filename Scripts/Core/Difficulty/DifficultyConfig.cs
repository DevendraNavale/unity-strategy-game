using UnityEngine;

[CreateAssetMenu(fileName = "DifficultyConfig", menuName = "Game/Difficulty Config")]
public class DifficultyConfig : ScriptableObject
{
    [Header("Time (seconds)")]
    public float earlyGameEnd = 60f;
    public float midGameEnd = 180f;

    [Header("Resource Multipliers")]
    public float earlyMultiplier = 1f;
    public float midMultiplier = 1.5f;
    public float lateMultiplier = 2.2f;
}
