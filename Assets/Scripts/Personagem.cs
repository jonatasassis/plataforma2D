using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Personagem : MonoBehaviour
{

    [Header("movimentacao")]
    public Rigidbody2D myRigidbody2D;
    public int velocidadeCaminhada,velocidadeCorrida,velocidadeAtual,forcaPulo;
    public Vector2 friccao = new Vector2(1f, 0);

    [Header("animacao")]
    public float stretchY = 1.5f;
    public float stretchX = 0.7f;
    public float duracaoAnimacao = 0.001f;
    public Ease ease = Ease.OutBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pulo();
        Movimentacao();
       
    }

    private void Movimentacao()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            velocidadeAtual = velocidadeCorrida;
        }
        else
        {
            velocidadeAtual = velocidadeCaminhada;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = new Vector2(velocidadeAtual, myRigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(-velocidadeAtual, myRigidbody2D.velocity.y);
        }

        if (myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= friccao;
        }
        if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += friccao;
        }
    }

    private void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigidbody2D.velocity = Vector2.up * forcaPulo;
            myRigidbody2D.transform.localScale= Vector2.one;
            DOTween.Kill(myRigidbody2D.transform);
            myRigidbody2D.transform.DOScaleY(stretchY,duracaoAnimacao).SetLoops(2,LoopType.Yoyo).SetEase(ease);
            myRigidbody2D.transform.DOScaleX(stretchX, duracaoAnimacao).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        }
    }
        
    
}
