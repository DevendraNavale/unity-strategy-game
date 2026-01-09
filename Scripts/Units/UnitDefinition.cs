using UnityEngine;

[CreateAssetMenu(fileName = "NewUnit", menuName = "Unit/Unit Definition")]
public class UnitDefinition : ScriptableObject
{
    [Header("Unit Info")]
    public string unitName;
    public int maxHP;
    public int damage;
    public float moveSpeed;

    [Header("Resource Costs")]
    public ResourceData goldResource;
    public int goldCost;
    public ResourceData energyResource;
    public int energyCost;
}
