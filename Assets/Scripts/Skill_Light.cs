using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Light : MonoBehaviour
{
    public PlayerController player;
    public SkillObjectManager SkillReferenceObject;
    public Skill400 _skill400;
    public Skill410 _skill410;
    public Skill420 _skill420;
    public Skill430 _skill430;
    public Skill440 _skill440;
    public Skill450 _skill450;

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
        _skill400 = new Skill400(SkillReferenceObject.L1_4[0]);
        _skill410 = new Skill410(SkillReferenceObject.L1_4[1]);
        _skill420 = new Skill420(SkillReferenceObject.L1_4[2]);
        _skill430 = new Skill430(SkillReferenceObject.L1_4[3]);
        _skill440 = new Skill440(SkillReferenceObject.L1_4[4]);
        _skill450 = new Skill450(SkillReferenceObject.L1_4[5]);
    }

    public class Skill400 : Skill
    {
        public Skill400(GameObject skillObject)
        {
            skillID = 400;
            skillName = "손전등 스포트라이트";
            skillDesc = "화려한 조명이 플레이어를 감싸 플레이어 주변 범위의 적들에게 지속적으로 피해를 입힌다.";
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
    public class Skill410 : Skill
    {
        public Skill410(GameObject skillObject)
        {
            skillID = 410;
            skillName = "꼼짝 마!";
            skillDesc = "플레이어 전방 원뿔 범위에 손전등을 비춰 적들에게 피해를 입히고 일정 시간동안 플레이어를 탐지하지 못하게 한다.";
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
    public class Skill420 : Skill
    {
        public Skill420(GameObject skillObject)
        {
            skillID = 420;
            skillName = "빛으로 강타해요";
            skillDesc = "플레이어의 전방으로 빛의 탄환을 발사한다. 빛의 탄환은 진행한 거리에 비례해 입히는 피해가 감소한다.";
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
    public class Skill430 : Skill
    {
        public Skill430(GameObject skillObject)
        {
            skillID = 430;
            skillName = "빛의 세례";
            skillDesc = "하늘에서 빛을 쏴 시야 범위 내 무작위 적들에게 순차적으로 피해를 입힌다.";
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
    public class Skill440 : Skill
    {
        public Skill440(GameObject skillObject)
        {
            skillID = 440;
            skillName = "광순응";
            skillDesc = "적이 스포트라이트에 데미지를 입은 시간에 비례해 스포트라이트로 받는 피해량이 증가한다.";
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
    public class Skill450 : Skill
    {
        public Skill450(GameObject skillObject)
        {
            skillID = 450;
            skillName = "과학 시간";
            skillDesc = "일정 시간동안 플레이어의 주위를 도는 볼록렌즈를 소환한다. 볼록렌즈는 빛을 모아 일직선으로 내보내며, 빛이 적중한 대상에게 지속적으로 피해를 입힌다.";
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
