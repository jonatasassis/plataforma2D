using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coletaveis : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UI.qtdMoedas++;
            Destroy(gameObject);
        }
    }
}
