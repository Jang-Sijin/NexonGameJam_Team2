using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillCollisionRetriever : MonoBehaviour
{
    public float Damage { get; set; }

    /// <summary>
    /// Correspondingly each skill has to free the list containing the colliders on execute
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetDamage(Damage);
        }
    }
}
