using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
    public static bool coleteiMoedaRoxa = false, coleteiMoedaVerde = false;
    public bool moedaRoxa,moedaVerde;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&moedaRoxa)
        {
            coleteiMoedaRoxa = true;
            Destroy(gameObject);
        }
        else if (collision.tag == "Player" && moedaVerde)
        {
            coleteiMoedaVerde = true;
            Destroy(gameObject);
        }
    }
}
