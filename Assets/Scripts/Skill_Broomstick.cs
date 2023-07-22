using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Broomstick : MonoBehaviour
{
    public PlayerController player = Managers.instance._player;
    public SkillObjectManager SkillReferenceObject;

    //private void Start()
    //{
    //    var obj = new Skill100(SkillReferenceObject.L1_1[0]);
    //    obj.SkillBehaviour(player);
    //}

    public class Skill100 : Skill
    {
        public Skill100(GameObject skillObject)
        {
            base.skillID = 100;
            base.skillName = "빗자루";
            base.skillDesc = "좌우로 적을 관통하는 근접공격을 합니다.";
            base.skillObject = skillObject;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            SpriteRenderer SR = skillObject.GetComponent<SpriteRenderer>();
            Collider2D collider = skillObject.GetComponent<BoxCollider2D>();
            while (true)
            {
                if (player._sprite.flipX)
                {
                    SR.flipX = true;
                    skillObject.transform.position = new Vector2(skillObject.transform.position.x, -skillObject.transform.position.y);
                }
                
                yield break;
            }
            yield return null;
        }
    }
}
