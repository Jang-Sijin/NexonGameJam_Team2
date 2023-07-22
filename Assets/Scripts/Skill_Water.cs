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
            skillName = "����ź �߻�";
            skillDesc = "��ź ��ġ�� ���� �������� ������ ����ź�� �߻��Ѵ�. ����ź�� ���� ����� ������ �������� �߻�ȴ�.";
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
            skillName = "����";
            skillDesc = "�÷��̾�κ��� ���� ����� ���� �������� �ĵ��� ��ȯ�Ѵ�. �ĵ��� ���� ���� �ĵ��� ����������� �ణ �з�����.";
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
    public class Skill220 : Skill
    {
        public Skill220(GameObject skillObject)
        {
            skillID = 220;
            skillName = "���̽���Ŷç����";
            skillDesc = "�÷��̾ �ٶ󺸴� �������� �ణ ������ ��ġ�� �����ʸ� ����Ʈ����.";
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
    public class Skill230 : Skill
    {
        public Skill230(GameObject skillObject)
        {
            skillID = 230;
            skillName = "ġ���� ����";
            skillDesc = "�÷��̾��� ü���� 2�ʴ� 1�� ȸ����Ų��.";
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
    public class Skill240 : Skill
    {
        public Skill240(GameObject skillObject)
        {
            skillID = 240;
            skillName = "��Ȱ�";
            skillDesc = "�÷��̾��� ���� ��ġ�� �Ȱ��� ��ȯ�� �Ȱ� �ӿ� �ִ� ���鿡�� ���������� ���ظ� ������.";
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
    public class Skill250 : Skill
    {
        public Skill250(GameObject skillObject)
        {
            skillID = 250;
            skillName = "���� ��";
            skillDesc = "�÷��̾� ������ ���� ������ ���� ������ �۾��� ���ظ� ������.";
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
