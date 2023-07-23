using UnityEngine;

// [무한맵]
public class Reposition : MonoBehaviour
{
    [SerializeField] private float _tileMoveDistance = 40;
    private Collider2D _collider2D;

    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }
    
    // 트리거 나갈 때
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) 
            return;
        
        // 플레이어 위치
        Vector3 playerPos = Managers.instance._player.transform.position;
        // 타입맵 위치
        Vector3 myPos = transform.position;

        // 플레이어와 타이맵 거리 절대값
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        // 이동 방향
        float difX = Mathf.Abs(dirX);
        float difY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;


        switch (transform.tag)
        {
            // 타일맵 이동
            case "Ground":
                if (Mathf.Abs(difX - difY) <= 5f)
                {
                    transform.Translate(Vector3.up * dirY * _tileMoveDistance);
                    transform.Translate(Vector3.right * dirX * _tileMoveDistance);
                }
                else if (difX >= difY)
                {
                    transform.Translate(Vector3.right * dirX * _tileMoveDistance);
                }
                else if (difX <= difY)
                {
                    transform.Translate(Vector3.up * dirY * _tileMoveDistance);
                }
                break;
            case "Enemy":
                if (_collider2D.enabled) transform.position = (playerPos + 15 * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f));
                break;
        }
    }


}