using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Cinemachine;

public class Personagem : MonoBehaviour
{
    [Header("setup")]
    public SOPlayer soplayer;

    [Header("movimentacao")]
    public Rigidbody2D myRigidbody2D;
    public GameObject spritePersonagem;
    public bool andando, pulando;

    [Header("player")]
    public GameObject player;
    public Vector3 posicaoRespawnPlayer;
    public int vidaInicial;
    public static int vidaAtual;
    public SpriteRenderer[] spritePlayer;
    public Color corFlash;
    public float duracaoFlash = 0.2f;
    public static bool morri = false;

    public Animator animator;

    [Header("camera")]
    public CinemachineVirtualCamera virtualCam;
    

    [Header("projectil player")]
    public GameObject projectilPlayer;
    public Vector2 posInicialProjectilPlayer;
    public Projectil refDirecao;

    // Start is called before the first frame update
    void Start()
    {
        soplayer.duracaoAnimacao = 0.001f;
        soplayer.stretchX = 0.7f;
        soplayer.stretchY= 1.5f;

      posicaoRespawnPlayer= player.transform.position;
        vidaAtual = vidaInicial;
        refDirecao.flipDirecaoProjectil = true;

    }

    // Update is called once per frame
    void Update()
    {
        Pulo();
        Movimentacao();
        ReceberDano();
        PlayerAtirar();
       
        virtualCam.LookAt = player.transform;
        virtualCam.Follow = player.transform;

    }

    private void Movimentacao()
    {

        if (Input.GetKey(KeyCode.Space) && morri != true)
        {
            soplayer.velocidadeAtual = soplayer.velocidadeCorrida;
            animator.Play("ANIM_Astronaut_Run");
            
        }
        else
        {
            soplayer.velocidadeAtual = soplayer.velocidadeCaminhada;
        }
        if (Input.GetKey(KeyCode.RightArrow) && morri != true)
        {
            refDirecao.flipDirecaoProjectil = true;
            myRigidbody2D.velocity = new Vector2(soplayer.velocidadeAtual, myRigidbody2D.velocity.y);
            animator.Play("ANIM_Astronaut_Run");
            
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && morri != true)
        {
            refDirecao.flipDirecaoProjectil = false;
            myRigidbody2D.velocity = new Vector2(-soplayer.velocidadeAtual, myRigidbody2D.velocity.y);
            animator.Play("ANIM_Astronaut_Run");
            
            

        }

        if (myRigidbody2D.velocity.x > 0)
        {
            myRigidbody2D.velocity -= soplayer.friccao;
            spritePersonagem.transform.rotation = Quaternion.identity;
        }
        if (myRigidbody2D.velocity.x < 0)
        {
            myRigidbody2D.velocity += soplayer.friccao;
            spritePersonagem.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (myRigidbody2D.velocity.x == 0 && morri!=true )
        {
            
            animator.Play("ANIM_Astronaut_Idle");
            
        }
        if (myRigidbody2D.velocity.y >0 && morri != true)
        {

            animator.Play("ANIM_Astronaut_Jump_Up");
            

        }
        
    }

    public void ReceberDano()
    {
        // player morreu
        if (vidaAtual <= 0)
        {
            morri = true;
            animator.Play("ANIM_Astronaut_Death");
            //
            vidaAtual = vidaInicial;

            for (int s = 0; s < spritePlayer.Length; s++)
            {
                spritePlayer[s].color = Color.white;
            }

           StartCoroutine(DelayRespawn());

        }

        //player sofreu dano, mas nao morreu
        else if (Projectil.atingiPlayer==true)
        {
            for (int s = 0; s < spritePlayer.Length; s++)
            {
                spritePlayer[s].DOColor(corFlash, duracaoFlash).SetLoops(2, LoopType.Yoyo);
            }
            Projectil.atingiPlayer= false;
        }
       

    }

    private void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pulando = true;
            myRigidbody2D.velocity = Vector2.up * soplayer.forcaPulo;
            
            myRigidbody2D.transform.localScale= new Vector2(0.3f,0.3f);
           
            DOTween.Kill(myRigidbody2D.transform);
            myRigidbody2D.transform.DOScaleY(soplayer.stretchY, soplayer.duracaoAnimacao).SetLoops(2,LoopType.Yoyo).SetEase(soplayer.ease);
            myRigidbody2D.transform.DOScaleX(soplayer.stretchX, soplayer.duracaoAnimacao).SetLoops(2, LoopType.Yoyo).SetEase(soplayer.ease);
        }

        
    }

    private void PlayerAtirar()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (refDirecao.flipDirecaoProjectil)
            {
                Instantiate(projectilPlayer, new Vector2(player.transform.position.x - posInicialProjectilPlayer.x, player.transform.position.y + posInicialProjectilPlayer.y), Quaternion.Euler(0,0,-223));
            }
            else
            {
                Instantiate(projectilPlayer, new Vector2(player.transform.position.x + posInicialProjectilPlayer.x, player.transform.position.y + posInicialProjectilPlayer.y), Quaternion.Euler(0, 0, -45));
            }
        }
        
    
}

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(2f);
        morri = false;
        player.transform.position = posicaoRespawnPlayer;
    }
}
