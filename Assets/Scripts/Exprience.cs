using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exprience : MonoBehaviour
{
    public int exp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Managers.instance.GetExp(exp);
            gameObject.SetActive(false);
        }
    }
}
