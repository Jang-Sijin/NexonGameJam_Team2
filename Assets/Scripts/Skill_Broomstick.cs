using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Broomstick : MonoBehaviour
{
    public PlayerController player = Managers.instance._player;
    public SkillObjectManager SkillReferenceObject;

    private void Start()
    {
        var obj = new Skill100(SkillReferenceObject.L1_1[0]);
        StartCoroutine(obj.SkillBehaviour(player));
    }

    public class Skill100 : Skill
    {
        Collider2D LocalCollider;
        public Skill100(GameObject skillObject)
        {
            skillID = 100;
            skillName = "빗자루";
            skillDesc = "좌우로 적을 관통하는 근접공격을 합니다.";
            base.skillObject = skillObject;
            LocalCollider = skillObject.GetComponent<Collider2D>();
            damage = 3f;
            coolDown = 1.5f;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            Vector2 initPos = skillObject.transform.localPosition;
            SpriteRenderer SR = skillObject.GetComponent<SpriteRenderer>();
            SkillCollisionRetriever SCR = skillObject.GetComponent<SkillCollisionRetriever>();
            SCR.ApplyDamage(3f);
            while (true)
            {
                skillObject.SetActive(true);
                SR.flipX = player._sprite.flipX;
                skillObject.transform.localPosition = SR.flipX ? new Vector2(-initPos.x, initPos.y) : new Vector2(initPos.x, initPos.y);

                //foreach (Collider2D collider in SCR.Rtrn)
                //{
                //    collider.GetComponent<EnemyController>().GetDamage(3f);
                //}

                yield return new WaitForSeconds(0.25f);
                SCR.Rtrn.Clear();
                skillObject.SetActive(false);
                yield return new WaitForSeconds(coolDown);

                //When off flag is set
                //skillObject.SetActive(false);
                //yield break;
            }
            yield return null;
        }
    }
}
