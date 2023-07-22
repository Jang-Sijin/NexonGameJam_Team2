using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillCollisionRetriever : MonoBehaviour
{
    public List<Collider> Rtrn = new List<Collider>();
    
    /// <summary>
    /// Correspondingly each skill has to free the list containing the colliders on execute
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!Rtrn.Contains(other))
        {
            Rtrn.Add(other);
        }
    }
}
