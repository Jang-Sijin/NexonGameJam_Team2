using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Object Asset/EnemyStat")]
public class EnemyData : ScriptableObject
{
    public float HP;
    public float damage;
    public float speed;
}
