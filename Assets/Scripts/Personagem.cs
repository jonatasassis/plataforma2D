using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
    public Animator animator;
    public GameObject spritePersonagem;
    public bool andando, pulando;
  
    
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
            animator.Play("ANIM_Astronaut_Run");
            
        }
        else
        {
            velocidadeAtual = velocidadeCaminhada;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity = new Vector2(velocidadeAtual, myRigidbody2D.velocity.y);
            animator.Play("ANIM_Astronaut_Run");
            
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(-velocidadeAtual, myRigidbody2D.velocity.y);
            animator.Play("ANIM_Astronaut_Run");
            
            

        }

        if (myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= friccao;
            spritePersonagem.transform.rotation = Quaternion.identity;
        }
        if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += friccao;
            spritePersonagem.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (myRigidbody2D.velocity.x == 0 )
        {
            
            animator.Play("ANIM_Astronaut_Idle");
            
        }
        if (myRigidbody2D.velocity.y >0 )
        {

            animator.Play("ANIM_Astronaut_Jump_Up");
            

        }
        
    }

    private void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pulando = true;
            myRigidbody2D.velocity = Vector2.up * forcaPulo;
            
            myRigidbody2D.transform.localScale= new Vector2(0.3f,0.3f);
           
            DOTween.Kill(myRigidbody2D.transform);
            myRigidbody2D.transform.DOScaleY(stretchY,duracaoAnimacao).SetLoops(2,LoopType.Yoyo).SetEase(ease);
            myRigidbody2D.transform.DOScaleX(stretchX, duracaoAnimacao).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        }

        
    }
        
    
}
