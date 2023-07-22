using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public float _damage;
    public int _count;
    public float _speed;
    float _timer;
    PlayerController _player;

    void Awake()
    {
        _player = Managers.instance._player;
    }
    
    void Update()
    {
        if (!Managers.instance.isLive) return;
        
        _timer += Time.deltaTime;
        if (_timer > _speed)
        {
            _timer = 0f;
            Fire();
        }
    }
    
        void Fire()
        {
            //if (!_player.scanner._nearTarget) return;
            //
            //Vector3 targetPos = _player.scanner._nearTarget.position;
            //Vector3 dir = targetPos - transform.position;
            //dir = dir.normalized;
            //
            //Transform bullet = Managers.instance.Pool.Get(_prefabId).transform;
            //bullet.position = transform.position;
            //
            //bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            //bullet.GetComponent<Bullet>().Init(_damage, _count, dir);
        }
}
