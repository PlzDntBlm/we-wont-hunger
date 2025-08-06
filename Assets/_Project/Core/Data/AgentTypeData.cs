using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAgentType", menuName = "We Won't Hunger/Agent Type")]
public class AgentTypeData : ScriptableObject
{
    [Header("Agent Info")]
    public string AgentName;

    [Header("Needs")]
    public float MaxHunger = 100f;
    public float HungerDecayRate = 1f;

    [Header("Lifecycle")]
    public float Lifespan = 60f;
    public float MaxHealth = 100f;

    [Header("Skills")]
    public List<SkillData> PotentialSkills;
}