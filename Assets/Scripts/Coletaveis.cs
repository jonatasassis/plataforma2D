using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{
    public static bool coleteiMoedaRoxa = false, coleteiMoedaVerde = false;
    public bool moedaRoxa,moedaVerde;
    public ParticleSystem efeitoMoeda;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        efeitoMoeda.Play();
        Destroy(gameObject,1);
        if (collision.tag == "Player"&&moedaRoxa)
        {
            coleteiMoedaRoxa = true;
            
            
        }
        else if (collision.tag == "Player" && moedaVerde)
        {
            coleteiMoedaVerde = true;
            
            
        }
    }
}
