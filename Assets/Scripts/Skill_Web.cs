using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Web : MonoBehaviour
{
    public PlayerController player;
    public SkillObjectManager SkillReferenceObject;
    public Skill300 _skill300;
    public Skill310 _skill310;
    public Skill320 _skill320;
    public Skill330 _skill330;
    public Skill340 _skill340;
    public Skill350 _skill350;

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
        _skill300 = new Skill300(SkillReferenceObject.L1_3[0]);
        _skill310 = new Skill310(SkillReferenceObject.L1_3[1]);
        _skill320 = new Skill320(SkillReferenceObject.L1_3[2]);
        _skill330 = new Skill330(SkillReferenceObject.L1_3[3]);
        _skill340 = new Skill340(SkillReferenceObject.L1_3[4]);
        _skill350 = new Skill350(SkillReferenceObject.L1_3[5]);
    }

    public class Skill300 : Skill
    {
        public Skill300(GameObject skillObject)
        {
            skillID = 300;
            skillName = "그물 덫";
            skillDesc = "플레이어 주위의 랜덤한 위치에 그물 덫을 설치해 밟은 적과 근처의 적들을 느려지게 만들고 데미지를 입힌다.";
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
    public class Skill310 : Skill
    {
        public Skill310(GameObject skillObject)
        {
            skillID = 310;
            skillName = "몰이사냥";
            skillDesc = "전방 원뿔 범위에 그물총을 발사해 범위 내에 있던 적들을 가운데로 끌어모은다.";
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
    public class Skill320 : Skill
    {
        public Skill320(GameObject skillObject)
        {
            skillID = 320;
            skillName = "절대그물을밟지마";
            skillDesc = "플레이어의 현재 위치에 즉사 그물을 설치한다. 즉사 그물이 발동되면 밟은 대상은 큰 피해를 입고, 주변에 일반 그물 덫이 설치된다.";
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
    public class Skill330 : Skill
    {
        public Skill330(GameObject skillObject)
        {
            skillID = 330;
            skillName = "얍얍얍얍얍";
            skillDesc = "작은 그물 탄환을 연속으로 발사해 적에게 피해를 입힌다.";
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
    public class Skill340 : Skill
    {
        public Skill340(GameObject skillObject)
        {
            skillID = 340;
            skillName = "사냥감이다가오기를기다리는거미의마음가짐으로";
            skillDesc = "1.5초 이상 가만히 있으면 플레이어의 주변에서부터 나선 형태로 그물 덫을 빠르게 설치한다.";
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
    public class Skill350 : Skill
    {
        public Skill350(GameObject skillObject)
        {
            skillID = 350;
            skillName = "공방일체";
            skillDesc = "그물 덫을 발사해 맞은 적들에게 피해를 입히고 플레이어는 뒤로 밀려난다.";
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
