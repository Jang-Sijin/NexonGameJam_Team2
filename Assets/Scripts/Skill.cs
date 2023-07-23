using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public enum SkillPosition { L1, L2, L3 };

    public int skillID;
    public string skillName;
    public string skillDesc;
    public Sprite skillIcon;
    public GameObject skillObject;
    public List<GameObject> spawnables;

    public int skillLevel;

    public float damage;
    public float coolDown;

    public abstract IEnumerator SkillBehaviour(PlayerController player);

    public void LevelUp()
    {
        skillLevel++;
        if (skillLevel == 1)
            return;
        damage += 2;
    }
}
