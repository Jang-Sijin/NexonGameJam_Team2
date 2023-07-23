using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Health; // 체력
    public float MaxHealth; // 최대 체력
    public RuntimeAnimatorController[] animCon; // 몬스터 애니메이션 컨트롤러
    public Rigidbody2D Target; // 적군 타겟
    public float damage;

    [SerializeField] private float _speed = 2.5f; // 이동 속도
    private Animator _animator; // 적군 애니메이터
    private bool _isLive; // 생존 체크
    private Rigidbody2D _rigidbody2D; 
    private SpriteRenderer _spriteRenderer; // 적군 이미지
    private Collider2D _collider2D;
    private WaitForFixedUpdate _wait;

    public EnemyData enemyData;

    void Awake()
    {
        // [컴포넌트 초기화]
        _collider2D = GetComponent<Collider2D>();
        _wait = new WaitForFixedUpdate();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // if (!_isLive || _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            //return;
        
        if (!Managers.instance.isLive) return;

        // 플레이어와의 거리 = 타겟(플레이어) 위치 - 적군 위치
        Vector2 dirVec = Target.position - _rigidbody2D.position;
        // 노말라이즈
        Vector2 nextVec = dirVec.normalized * _speed * Time.fixedDeltaTime;
        
        // 적군 이동
        _rigidbody2D.MovePosition(_rigidbody2D.position + nextVec);
        // 중력 적용 x
        _rigidbody2D.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!_isLive) return;
        if (!Managers.instance.isLive) return;
    
        _spriteRenderer.flipX = Target.position.x < _rigidbody2D.position.x;
    }

    private void OnEnable()
    {
        Target = Managers.instance._player.GetComponent<Rigidbody2D>();
        _isLive = true;
        _collider2D.enabled = true;
        _rigidbody2D.simulated = true;
        _spriteRenderer.sortingOrder = 2;
        _animator.SetBool("Dead", false);
        Health = enemyData.HP;
    }

    public void Init()
    {
        // _animator.runtimeAnimatorController = animCon[data._spriteType];
        _speed = enemyData.speed;// * Managers.instance._player._moveSpeed;
        MaxHealth = enemyData.HP;
        Health = enemyData.HP;
        damage = enemyData.damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (!collision.CompareTag("Bullet")|| !_isLive) return;

        // _health -= collision.GetComponent<Bullet>()._damage;
        //StartCoroutine(KnockBack());
        // if (Health > 0)
        // {
        //     _animator.Play("Hit");
        // }
        //else
        //{
        //    _isLive = false;
        //    _collider2D.enabled = false;
        //    _rigidbody2D.simulated = false;
        //    _spriteRenderer.sortingOrder = 1;
        //    //_animator.SetBool("Dead",true);
        //    Managers.instance.kill++;
        //    Managers.instance.GetExp();
        //
        //}

    }

    IEnumerator KnockBack()
    {
        yield return _wait;
        Vector3 playerPos = Managers.instance._player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        _rigidbody2D.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

    }

    public void GetDamage(float dmg)
    {
        if (Health <= dmg)
        {
            Health = 0;
            Dead();
        }
        else
        {
            Health -= dmg;
        }
    }

    void Dead()
    {
        GameObject exp = Managers.instance.Pool.Get(7);
        exp.transform.position = transform.localPosition;
        gameObject.SetActive(false);
    }
}
