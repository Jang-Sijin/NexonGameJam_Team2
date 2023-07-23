using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Scanner scanner;
    //public Hand[] hands;
    public Vector2 _inputVector;                    // 플레이어 이동 벡터
    private Rigidbody2D _rigidbody2D;               // 플레이어 리지드바디
    public float _moveSpeed = 8f;                  // 플레이어 이동 속도
    private int _damage = 10;                       // 플레이어가 받는 대미지
    private Animator _animator;
    public SpriteRenderer _sprite;
    public bool isBarrierActive = false;
    public float barrierValue = 0f;
    private static readonly int PlayerRun = Animator.StringToHash("Player_Run");

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        // hands = GetComponentsInChildren<Hand>(true);
        // scanner = GetComponent<Scanner>();
    }

    void Update()
    {
        // 플레이어가 생존 상태가 아닐 때
        if (!Managers.instance.isLive) 
            return;

        // 플레이어가 생존 상태일 때, 이동관련 키입력 처리
        _inputVector.x = Input.GetAxisRaw("Horizontal");
        _inputVector.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // 플레이어가 생존 상태가 아닐 때
        if (!Managers.instance.isLive) 
            return;
        
        // 플레이어 이동 처리
        _rigidbody2D.MovePosition(_rigidbody2D.position + _inputVector.normalized * _moveSpeed * Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        // 플레이어가 생존 상태가 아닐 때
        if (!Managers.instance.isLive)
            return;

        // 플레이어의 체력이 0보다 작을 때
        if (Managers.instance.health < 0)
            return;

        // 플레이어가 이동중일 떄 처리 내용
        if (_inputVector.x != 0)
        {
            _animator.SetFloat("Speed", _inputVector.magnitude);
            _sprite.flipX = _inputVector.x < 0;
        }
        else // 플레이어가 이동중이 아닐 떄 처리 내용
        {
            _animator.SetFloat("Speed", _inputVector.magnitude);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 플레이어가 생존 상태가 아닐 때
        if (!Managers.instance.isLive) 
            return;

        // 플레이어가 적군한테 초당 대미지를 받는다.
        if (isBarrierActive)
        {
            barrierValue -= Time.deltaTime * collision.gameObject.GetComponent<EnemyController>().enemyData.damage;
            if (barrierValue < 0f)
            {
                isBarrierActive = false;
                barrierValue = 0f;
            }
        }
        else
        {
            Managers.instance.health -= Time.deltaTime * collision.gameObject.GetComponent<EnemyController>().enemyData.damage;
        }

        // 플레이어의 체력이 0보다 작을 때(플레이어가 죽었을 경우)
        if (Managers.instance.health < 0)
        {
            // 모든 오브젝트 Active False
            for (int i = 2; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
            // 사망 애니메이션 출력
            // _anim.Play("Dead");
            
            // 게임오버 처리
            Managers.instance.GameOver();
        }

    }

}
