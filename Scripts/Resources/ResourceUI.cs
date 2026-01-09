using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    public ResourceManager resourceManager;
    public ResourceData gold;
    public ResourceData energy;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text =
            $"Gold: {resourceManager.GetResource(gold)}\n" +
            $"Energy: {resourceManager.GetResource(energy)}";
    }
}