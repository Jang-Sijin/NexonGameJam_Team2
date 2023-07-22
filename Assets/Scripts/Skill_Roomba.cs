using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Roomba : MonoBehaviour
{
    public PlayerController player;
    public SkillObjectManager SkillReferenceObject;
    public Skill500 _skill500;
    public Skill510 _skill510;
    public Skill520 _skill520;
    public Skill530 _skill530;
    public Skill540 _skill540;
    public Skill550 _skill550;

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
        _skill500 = new Skill500(SkillReferenceObject.L1_5[0]);
        _skill510 = new Skill510(SkillReferenceObject.L1_5[1]);
        _skill520 = new Skill520(SkillReferenceObject.L1_5[2]);
        _skill530 = new Skill530(SkillReferenceObject.L1_5[3]);
        _skill540 = new Skill540(SkillReferenceObject.L1_5[4]);
        _skill550 = new Skill550(SkillReferenceObject.L1_5[5]);
    }

    public class Skill500 : Skill
    {
        public Skill500(GameObject skillObject)
        {
            skillID = 500;
            skillName = "애완 로봇 청소기";
            skillDesc = "자동으로 움직이며 닿는 적에게 피해를 입히는 로봇 청소기를 소환한다.";
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
    public class Skill510 : Skill
    {
        public Skill510(GameObject skillObject)
        {
            skillID = 510;
            skillName = "로봇 회오리";
            skillDesc = "플레이어를 중심으로 나선형의 궤적으로 로봇 청소기를 발사해 적에게 피해를 입힌다.";
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
    public class Skill520 : Skill
    {
        public Skill520(GameObject skillObject)
        {
            skillID = 520;
            skillName = "로봇 송풍기...?";
            skillDesc = "로봇 청소기와 같은 방식으로 움직이며 전방 원뿔 범위에 피해를 입히는 로봇 송풍기를 소환한다.";
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
    public class Skill530 : Skill
    {
        public Skill530(GameObject skillObject)
        {
            skillID = 530;
            skillName = "청소기의 어깨에 올라서라";
            skillDesc = "로봇 청소기를 플레이어에게 불러들이고 위에 탑승한다. 청소기에 탑승한 동안은 받는 피해가 감소한다.";
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
    public class Skill540 : Skill
    {
        public Skill540(GameObject skillObject)
        {
            skillID = 540;
            skillName = "엄청나고강력하고굉장하고대단한";
            skillDesc = "소환수의 크기와 공격범위를 늘린다.";
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
    public class Skill550 : Skill
    {
        public Skill550(GameObject skillObject)
        {
            skillID = 550;
            skillName = "이동식 전자기장 발생 장치";
            skillDesc = "로봇 청소기가 주변의 적들을 느려지게 만드는 자기장을 방출한다.";
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
