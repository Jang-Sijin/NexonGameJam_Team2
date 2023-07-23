using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobExplode : MonoBehaviour
{
    public GameObject NextObject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(NextObject, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
        Destroy(this.gameObject);
    }
}
