using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    public List<ResourceData> resources; // Drag Gold & Energy assets here

    private Dictionary<ResourceData, int> resourceValues = new();

    private void Start()
    {
        foreach (var resource in resources)
        {
            resourceValues[resource] = resource.startAmount;
            StartCoroutine(GenerateResource(resource));
        }
    }

    private IEnumerator GenerateResource(ResourceData resource)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            resourceValues[resource] += resource.generationPerSecond;
        }
    }

    public int GetResource(ResourceData resource)
    {
        if (resource == null || !resourceValues.ContainsKey(resource)) return 0;
        return resourceValues[resource];
    }

    public bool HasEnough(ResourceData resource, int amount)
    {
        if (resource == null) return false;
        return resourceValues.ContainsKey(resource) && resourceValues[resource] >= amount;
    }

    public void Spend(ResourceData resource, int amount)
    {
        if (resource == null || !resourceValues.ContainsKey(resource)) return;

        resourceValues[resource] -= amount;
        if (resourceValues[resource] < 0)
            resourceValues[resource] = 0;
    }
}
