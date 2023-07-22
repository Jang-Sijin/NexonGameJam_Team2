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
            skillName = "�ֿ� �κ� û�ұ�";
            skillDesc = "�ڵ����� �����̸� ��� ������ ���ظ� ������ �κ� û�ұ⸦ ��ȯ�Ѵ�.";
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
            skillName = "�κ� ȸ����";
            skillDesc = "�÷��̾ �߽����� �������� �������� �κ� û�ұ⸦ �߻��� ������ ���ظ� ������.";
            base.skillObject = skillObject;
            damage = 3f;
            coolDown = 5f;
            skillLevel = 0;
            //���� �Ÿ�: 8 CM
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }

    //TODO: ���ڷ� ��������Ʈ ����
    public class Skill520 : Skill
    {
        public Skill520(GameObject skillObject)
        {
            skillID = 520;
            skillName = "�κ� ��ǳ��...?";
            skillDesc = "�κ� û�ұ�� ���� ������� �����̸� ���� ���� ������ ���ظ� ������ �κ� ��ǳ�⸦ ��ȯ�Ѵ�.";
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

    //TODO: ��ų ����
    public class Skill530 : Skill
    {
        public Skill530(GameObject skillObject)
        {
            skillID = 530;
            skillName = "û�ұ��� ����� �ö󼭶�";
            skillDesc = "�κ� û�ұ⸦ �÷��̾�� �ҷ����̰� ���� ž���Ѵ�. û�ұ⿡ ž���� ������ �޴� ���ذ� �����Ѵ�.";
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

    //TODO: ��ų ����
    public class Skill540 : Skill
    {
        public Skill540(GameObject skillObject)
        {
            skillID = 540;
            skillName = "��û�������ϰ����ϰ�����";
            skillDesc = "��ȯ���� ũ��� ���ݹ����� �ø���.";
            base.skillObject = skillObject;
            damage = 1.5f;
            coolDown = 7f;
            skillLevel = 0;
            //�����ð� 3��
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
            skillName = "�̵��� ���ڱ��� �߻� ��ġ";
            skillDesc = "�κ� û�ұⰡ �ֺ��� ������ �������� ����� �ڱ����� �����Ѵ�.";
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
