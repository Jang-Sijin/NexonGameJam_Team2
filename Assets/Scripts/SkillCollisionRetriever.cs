using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillCollisionRetriever : MonoBehaviour
{
    public List<Collider2D> Rtrn = new List<Collider2D>();

    /// <summary>
    /// Correspondingly each skill has to free the list containing the colliders on execute
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("asdf");
        if (other.CompareTag("Enemy"))
        {
            if (!Rtrn.Contains(other))
            {
                Rtrn.Add(other);
            }
        }
    }
}
