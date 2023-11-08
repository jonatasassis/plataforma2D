using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int danoInimigo=10;

    private void OnCollisionEnter2D(Collision2D col)
    {
        var hp = col.gameObject.GetComponent<HP>();

        if (hp != null)
        {
            hp.Dano(danoInimigo);
        }
    }
}
