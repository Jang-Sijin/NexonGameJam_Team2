using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillCollisionRetriever : MonoBehaviour
{
    public List<Collider2D> Rtrn = new List<Collider2D>();
    private float damage;

    /// <summary>
    /// Correspondingly each skill has to free the list containing the colliders on execute
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetDamage(damage);
            /*if (!Rtrn.Contains(other))
            {
                Rtrn.Add(other);
            }*/
        }
    }

    public void ApplyDamage(float Damage)
    {
        damage = Damage;
    }
}
