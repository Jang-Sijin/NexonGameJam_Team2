using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Broomstick : MonoBehaviour
{
    public PlayerController player = Managers.instance._player;
    public SkillObjectManager SkillReferenceObject;
    public Skill100 _skill100;

    public void LevelUp(Skill skill)
    {
        skill.skillLevel++;
        if (skill.skillLevel == 1)
        {
            StartCoroutine(skill.SkillBehaviour(player));
        }
    }

    private void Start()
    {
        _skill100 = new Skill100(SkillReferenceObject.L1_1[0]);
        
         //StartCoroutine(_skill100.SkillBehaviour(player));
    }

    public class Skill100 : Skill
    {
        public Skill100(GameObject skillObject)
        {
            skillID = 100;
            skillName = "빗자루";
            skillDesc = "좌우로 적을 관통하는 근접공격을 합니다.";
            base.skillObject = skillObject;
            damage = 3f;
            coolDown = 1.5f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            Vector2 initPos = skillObject.transform.localPosition;
            SpriteRenderer SR = skillObject.GetComponent<SpriteRenderer>();
            SkillCollisionRetriever SCR = skillObject.GetComponent<SkillCollisionRetriever>();
            SCR.Damage = this.damage;
            while (true)
            {
                skillObject.SetActive(true);
                SR.flipX = player._sprite.flipX;
                skillObject.transform.localPosition = SR.flipX ? new Vector2(-initPos.x, initPos.y) : new Vector2(initPos.x, initPos.y);
                yield return new WaitForSeconds(0.25f);
                skillObject.SetActive(false);
                yield return new WaitForSeconds(coolDown);

                //When off flag is set
                //skillObject.SetActive(false);
                //yield break;
            }
            yield return null;
        }

        public void expup(int i)
        {
            skillLevel++;
            
        }
    }
}
