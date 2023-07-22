using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public enum SkillLevel { L1, L2, L3 };

    public int skillID;
    public string skillName;
    public string skillDesc;
    public Sprite skillIcon;
    public GameObject skillObject;

    public float damage;
    public float coolDown;

    public abstract IEnumerator SkillBehaviour(PlayerController player);
}
