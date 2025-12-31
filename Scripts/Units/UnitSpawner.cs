using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [Header("References")]
    public ResourceManager resourceManager;
    public GameObject unitPrefab;
    public Transform spawnPoint;

    [Header("Unit Data")]
    public UnitDefinition soldierData;
    public UnitDefinition heavyUnitData;

    public void SpawnSoldier() => TrySpawn(soldierData);
    public void SpawnHeavy() => TrySpawn(heavyUnitData);

    private void TrySpawn(UnitDefinition data)
    {
        if (data == null || resourceManager == null) return;

        if (!resourceManager.HasEnough(data.goldResource, data.goldCost)) return;
        if (!resourceManager.HasEnough(data.energyResource, data.energyCost)) return;

        // Deduct resources
        resourceManager.Spend(data.goldResource, data.goldCost);
        resourceManager.Spend(data.energyResource, data.energyCost);

        // Spawn unit
        GameObject unitObj = Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
        unitObj.GetComponent<UnitController>().unitData = data;
    }
}
