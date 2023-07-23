using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Water : MonoBehaviour
{
    public PlayerController player;
    public SkillObjectManager SkillReferenceObject;
    public Skill200 _skill200;
    public Skill210 _skill210;
    public Skill220 _skill220;
    public Skill230 _skill230;
    public Skill240 _skill240;
    public Skill250 _skill250;

    public void LevelUp(Skill skill)
    {
        skill.LevelUp();
        if (skill.skillLevel == 1)
        {
            StartCoroutine(skill.SkillBehaviour(player));
        }
    }

    private void Start()
    {
        player = Managers.instance._player;
        _skill200 = new Skill200(SkillReferenceObject.L1_2[0]);
        _skill210 = new Skill210(SkillReferenceObject.L1_2[1]);
        _skill220 = new Skill220(SkillReferenceObject.L1_2[2]);
        _skill230 = new Skill230(SkillReferenceObject.L1_2[3]);
        _skill240 = new Skill240(SkillReferenceObject.L1_2[4]);
        _skill250 = new Skill250(SkillReferenceObject.L1_2[5]);
    }

    public class Skill200 : Skill
    {
        public Skill200(GameObject skillObject)
        {
            skillID = 200;
            skillName = "물포탄 발사";
            skillDesc = "착탄 위치에 범위 데미지를 입히는 물포탄을 발사한다. 물포탄은 가장 가까운 몬스터의 방향으로 발사된다.";
            base.skillObject = skillObject;
            damage = 3f;
            coolDown = 1.5f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }
    public class Skill210 : Skill
    {
        public Skill210(GameObject skillObject)
        {
            skillID = 210;
            skillName = "해일";
            skillDesc = "플레이어로부터 가장 가까운 적의 방향으로 파도를 소환한다. 파도에 맞은 적은 파도의 진행방향으로 약간 밀려난다.";
            base.skillObject = skillObject;
            damage = 3f;
            coolDown = 5f;
            skillLevel = 0;
            //진행 거리: 8 CM
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }

    //TODO: 빗자루 스프라이트 적용
    public class Skill220 : Skill
    {
        public Skill220(GameObject skillObject)
        {
            skillID = 220;
            skillName = "아이스버킷챌린지";
            skillDesc = "플레이어가 바라보는 방향으로 약간 떨어진 위치에 물세례를 떨어트린다.";
            base.skillObject = skillObject;
            damage = 4f;
            coolDown = 2f;
            skillLevel = 0;
        }

        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }

    //TODO: 스킬 구현
    public class Skill230 : Skill
    {
        public Skill230(GameObject skillObject)
        {
            skillID = 230;
            skillName = "치유의 성수";
            skillDesc = "플레이어의 체력을 2초당 1씩 회복시킨다.";
            base.skillObject = skillObject;
            damage = -1f;
            coolDown = 2f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }

    //TODO: 스킬 구현
    public class Skill240 : Skill
    {
        public Skill240(GameObject skillObject)
        {
            skillID = 240;
            skillName = "밤안개";
            skillDesc = "플레이어의 현재 위치에 안개를 소환해 안개 속에 있는 적들에게 지속적으로 피해를 입힌다.";
            base.skillObject = skillObject;
            damage = 1.5f;
            coolDown = 7f;
            skillLevel = 0;
            //유지시간 3초
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }
    public class Skill250 : Skill
    {
        public Skill250(GameObject skillObject)
        {
            skillID = 250;
            skillName = "물의 검";
            skillDesc = "플레이어 전방의 원뿔 범위를 물의 검으로 휩쓸어 피해를 입힌다.";
            base.skillObject = skillObject;
            damage = 6f;
            coolDown = 3f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }
}
