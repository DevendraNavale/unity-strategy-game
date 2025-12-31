using UnityEngine;

[CreateAssetMenu(fileName = "NewResource", menuName = "Resources/Resource")]
public class ResourceData : ScriptableObject
{
    public string resourceName;
    public int startAmount;
    public int generationPerSecond;
}
