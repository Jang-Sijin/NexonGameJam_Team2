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
            skillName = "�׹� ��";
            skillDesc = "�÷��̾� ������ ������ ��ġ�� �׹� ���� ��ġ�� ���� ���� ��ó�� ������ �������� ����� �������� ������.";
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
            skillName = "���̻��";
            skillDesc = "���� ���� ������ �׹����� �߻��� ���� ���� �ִ� ������ ����� ���������.";
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
    public class Skill320 : Skill
    {
        public Skill320(GameObject skillObject)
        {
            skillID = 320;
            skillName = "����׹���������";
            skillDesc = "�÷��̾��� ���� ��ġ�� ��� �׹��� ��ġ�Ѵ�. ��� �׹��� �ߵ��Ǹ� ���� ����� ū ���ظ� �԰�, �ֺ��� �Ϲ� �׹� ���� ��ġ�ȴ�.";
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
    public class Skill330 : Skill
    {
        public Skill330(GameObject skillObject)
        {
            skillID = 330;
            skillName = "������";
            skillDesc = "���� �׹� źȯ�� �������� �߻��� ������ ���ظ� ������.";
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
    public class Skill340 : Skill
    {
        public Skill340(GameObject skillObject)
        {
            skillID = 340;
            skillName = "��ɰ��̴ٰ����⸦��ٸ��°Ź��Ǹ�����������";
            skillDesc = "1.5�� �̻� ������ ������ �÷��̾��� �ֺ��������� ���� ���·� �׹� ���� ������ ��ġ�Ѵ�.";
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
    public class Skill350 : Skill
    {
        public Skill350(GameObject skillObject)
        {
            skillID = 350;
            skillName = "������ü";
            skillDesc = "�׹� ���� �߻��� ���� ���鿡�� ���ظ� ������ �÷��̾�� �ڷ� �з�����.";
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
