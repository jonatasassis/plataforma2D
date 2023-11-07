using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    public GameObject botao;
    public int delay;
    public float tamanhoAtual;
    // Start is called before the first frame update
    void Start()
    {
        botao.transform.localScale = Vector3.zero;
        

        tamanhoAtual = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (tamanhoAtual<=1 )
        {
            tamanhoAtual = tamanhoAtual + 0.3f;
        }
        botao.transform.localScale= new Vector3 (tamanhoAtual,tamanhoAtual,1);
    }
}
