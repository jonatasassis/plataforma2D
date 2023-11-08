using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Botoes : MonoBehaviour
{
    public GameObject botao;
    public float duracaoDoScale;
    public Ease ease = Ease.OutBack;
    // Start is called before the first frame update
    void Start()
    {
        EsconderBotao();
        MostrarBotao();
   
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public void MostrarBotao()
    {
        botao.transform.DOScale(1, duracaoDoScale);
    }

    public void EsconderBotao()
    {
        botao.transform.localScale = Vector3.zero;
    }
}
