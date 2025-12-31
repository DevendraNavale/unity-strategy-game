using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;     // prefab from Assets
    public Transform spawnPoint;

    GameObject currentEnemy;

    public void SpawnEnemy()
    {
        if (currentEnemy != null) return;

        currentEnemy = Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }

    public void OnEnemyKilled()
    {
        currentEnemy = null;
        Invoke(nameof(SpawnEnemy), 1.5f); // spawn next enemy
    }
}
