using UnityEngine;

[CreateAssetMenu(fileName = "NewAgentType", menuName = "We Won't Hunger/Agent Type")]
public class AgentTypeData : ScriptableObject
{
    [Header("Agent Info")]
    public string AgentName;

    [Header("Needs")]
    public float MaxHunger = 100f;
    public float HungerDecayRate = 1f;
}