using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "We Won't Hunger/Skill")]
public class SkillData : ScriptableObject
{
    [Header("Skill Info")]
    public string SkillName;
    [TextArea] public string Description;
}