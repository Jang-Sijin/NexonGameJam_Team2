using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Light : MonoBehaviour
{
    public PlayerController player = Managers.instance._player;
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
            skillName = "������ ����Ʈ����Ʈ";
            skillDesc = "ȭ���� ������ �÷��̾ ���� �÷��̾� �ֺ� ������ ���鿡�� ���������� ���ظ� ������.";
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
            skillName = "��¦ ��!";
            skillDesc = "�÷��̾� ���� ���� ������ �������� ���� ���鿡�� ���ظ� ������ ���� �ð����� �÷��̾ Ž������ ���ϰ� �Ѵ�.";
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
    public class Skill420 : Skill
    {
        public Skill420(GameObject skillObject)
        {
            skillID = 420;
            skillName = "������ ��Ÿ�ؿ�";
            skillDesc = "�÷��̾��� �������� ���� źȯ�� �߻��Ѵ�. ���� źȯ�� ������ �Ÿ��� ����� ������ ���ذ� �����Ѵ�.";
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
    public class Skill430 : Skill
    {
        public Skill430(GameObject skillObject)
        {
            skillID = 430;
            skillName = "���� ����";
            skillDesc = "�ϴÿ��� ���� �� �þ� ���� �� ������ ���鿡�� ���������� ���ظ� ������.";
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
    public class Skill440 : Skill
    {
        public Skill440(GameObject skillObject)
        {
            skillID = 440;
            skillName = "������";
            skillDesc = "���� ����Ʈ����Ʈ�� �������� ���� �ð��� ����� ����Ʈ����Ʈ�� �޴� ���ط��� �����Ѵ�.";
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
    public class Skill450 : Skill
    {
        public Skill450(GameObject skillObject)
        {
            skillID = 450;
            skillName = "���� �ð�";
            skillDesc = "���� �ð����� �÷��̾��� ������ ���� ���Ϸ�� ��ȯ�Ѵ�. ���Ϸ���� ���� ��� ���������� ��������, ���� ������ ��󿡰� ���������� ���ظ� ������.";
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
