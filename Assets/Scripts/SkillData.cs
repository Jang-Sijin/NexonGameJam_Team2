using UnityEngine;

public class SkillData : ScriptableObject
{
    public enum SkillType{ Broomstick, WaterCannon, NetTrap, Spotlight, RobotCleaner}

    [Header("# Main Info")]
    public SkillType skillType;
    public int skillID;
    public string skillName;
    public string skillDesc;
    public Sprite skillIcon;
    
    //[Header("# Level Data")]
    
    //[Header("# Item")]
}
