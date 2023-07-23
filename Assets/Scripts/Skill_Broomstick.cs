using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Broomstick : MonoBehaviour
{
    public PlayerController player;
    public SkillObjectManager SkillReferenceObject;
    public Skill100 _skill100;
    public Skill110 _skill110;
    public Skill120 _skill120;
    public Skill130 _skill130;
    public Skill140 _skill140;
    public Skill150 _skill150;

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
        _skill100 = new Skill100(SkillReferenceObject.L1_1[0]);
        _skill110 = new Skill110(SkillReferenceObject.L1_1[1]);
        _skill120 = new Skill120(SkillReferenceObject.L1_1[2]);
        _skill130 = new Skill130(SkillReferenceObject.L1_1[3]);
        _skill140 = new Skill140(SkillReferenceObject.L1_1[4]);
        _skill150 = new Skill150(SkillReferenceObject.L1_1[5]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LevelUp(_skill100);
            LevelUp(_skill110);
            LevelUp(_skill120);
            LevelUp(_skill130);
            LevelUp(_skill150);
        }
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
    }
    public class Skill110 : Skill
    {
        public Skill110(GameObject skillObject)
        {
            skillID = 110;
            skillName = "이기어검술";
            skillDesc = "플레이어가 바라보는 방향으로 빗자루가 날아갔다 돌아오며 경로에 있는 적들에게 피해를 줍니다.";
            base.skillObject = skillObject;
            damage = 4f;
            coolDown = 2f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            skillObject.SetActive(true);
            SkillCollisionRetriever SCR = skillObject.GetComponent<SkillCollisionRetriever>();
            while (true)
            {
                SCR.Damage = this.damage;
                Vector2 Dir = player._inputVector;
                if (Dir.magnitude < 0.01f)
                {
                    if (player._sprite.flipX)
                    {
                        Dir = Vector2.left;
                    }
                    else
                    {
                        Dir = Vector2.right;
                    }
                }
                Vector3.Normalize(Dir);

                skillObject.transform.rotation = Quaternion.LookRotation(Vector3.forward, Dir);
                Vector2 initPos = skillObject.transform.position;
                Vector2 destPos = initPos + Dir * 4f;
                //skillObject.transform.rotation = Quaternion.FromToRotation(initPos, destPos);
                float elapsedTime = 0f;
                while (elapsedTime < 0.3f)
                {
                    skillObject.transform.position = Vector2.Lerp(initPos, destPos, elapsedTime / 0.3f);
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                yield return new WaitForSeconds(0.1f);
                elapsedTime = 0f;
                Quaternion initRotation = skillObject.transform.rotation;
                while (elapsedTime < 1f)
                {
                    skillObject.transform.position = Vector2.Lerp(destPos, player.transform.position + (Vector3.right * 0.5f), elapsedTime);
                    skillObject.transform.rotation = Quaternion.Slerp(initRotation, Quaternion.identity, elapsedTime);
                    elapsedTime += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                SCR.Damage = 0f;
                yield return new WaitForSeconds(coolDown);

                //When off flag is set
                //skillObject.SetActive(false);
                //yield break;
            }
            yield return null;
        }
    }

    //TODO: 빗자루 스프라이트 적용
    public class Skill120 : Skill
    {
        public Skill120(GameObject skillObject)
        {
            skillID = 120;
            skillName = "소용돌이치는 빗자루";
            skillDesc = "플레이어의 현재 위치에 회전하는 빗자루를 설치해서 닿는 적들에게 지속적으로 피해를 입힌다.";
            base.skillObject = skillObject;
            damage = 1f;
            coolDown = 2f;
            skillLevel = 0;
        }

        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            Transform originalParent = skillObject.transform.parent;
            SkillCollisionRetriever_TriggerStay SCR = skillObject.GetComponent<SkillCollisionRetriever_TriggerStay>();
            while (true)
            {
                skillObject.transform.position = player.transform.position;
                skillObject.transform.SetParent(null);
                skillObject.SetActive(true);
                SoundManager.Instance.PlaySFXSound("Broomstick_Attack");
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                SCR.Damage = 0f;
                yield return new WaitForSeconds(0.5f);
                SCR.Damage = this.damage;
                yield return new WaitForEndOfFrame();
                yield return new WaitForEndOfFrame();
                skillObject.SetActive(false);
                skillObject.transform.SetParent(originalParent);
                yield return new WaitForSeconds(coolDown);

                //When off flag is set
                //skillObject.SetActive(false);
                //yield break;
            }
            yield return null;
        }
    }


    public class Skill130 : Skill
    {
        public Skill130(GameObject skillObject)
        {
            skillID = 130;
            skillName = "빗자루가 지킨다";
            skillDesc = "빗자루로 방벽을 세워 피해를 흡수하는 보호막을 얻는다.";
            base.skillObject = skillObject;
            damage = 0f;
            coolDown = 30f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            while (true)
            {
                player.isBarrierActive = true;
                player.barrierValue = 15f;
                yield return new WaitForSeconds(30f);
            }
            yield return null;
        }
    }

    //TODO: 스킬 구현
    public class Skill140 : Skill
    {
        public Skill140(GameObject skillObject)
        {
            skillID = 140;
            skillName = "공포의 빗자루";
            skillDesc = "빗자루를 휘둘러 적중한 적들을 밀쳐낸다. ";
            base.skillObject = skillObject;
            damage = 3f;
            coolDown = 2.5f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            yield return null;
        }
    }
    public class Skill150 : Skill
    {
        public Skill150(GameObject skillObject)
        {
            skillID = 150;
            skillName = "바닥쓸기";
            skillDesc = "빗자루로 바닥을 크게 휩쓸며 플레이어 중심 원형 범위에 피해를 입힌다.";
            base.skillObject = skillObject;
            damage = 5f;
            coolDown = 2.5f;
            skillLevel = 0;
        }
        public override IEnumerator SkillBehaviour(PlayerController player)
        {
            SkillCollisionRetriever SCR = skillObject.GetComponent<SkillCollisionRetriever>();
            SCR.Damage = this.damage;
            while (true)
            {
                skillObject.SetActive(true);
                SoundManager.Instance.PlaySFXSound("Broomstick_Attack");
                yield return new WaitForSeconds(0.4f);
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
