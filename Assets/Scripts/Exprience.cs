using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exprience : MonoBehaviour
{
    public int exp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Managers.instance.GetExp();
        gameObject.SetActive(false);
    }
}
