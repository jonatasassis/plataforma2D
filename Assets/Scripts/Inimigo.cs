using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int danoInimigo=10,x,y, cooldownProjectil,vidaInicialInimigo;
    public Personagem personagem;
    public GameObject projectilInimigo,inimigo;
    public Vector2 posInicialProjectilInimigo;
    public SpriteRenderer[] olhosInimigo;
    public SpriteRenderer corpoInimigo;
    public Color corFlashOlhosInimigos,corFlashCorpoInimigo;
    public static int vidaAtualInimigo;
    public Animator animator;
    public bool inimigoMorto=false;
     

    private void Awake()
    {
        
        vidaAtualInimigo = vidaInicialInimigo;
    }
    private void Update()
    {
        InimigoAtacar();
        InimigoReceberDano();

    }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Personagem.vidaAtual = 0;
               
            }
        }
    public void InimigoAtacar()
    {
        if (inimigoMorto != true)
        {
            if (cooldownProjectil > 0)
            {
                cooldownProjectil--;

            }
            
            if (Personagem.playerEmPerigo && Personagem.morri == false)
            {
                for (int s = 0; s < olhosInimigo.Length; s++)
                {
                    olhosInimigo[s].color = corFlashOlhosInimigos;
                }
                if (cooldownProjectil == 0)
                {
                    animator.Play("ANIM_Enemy_2_Attack");
                    Instantiate(projectilInimigo, posInicialProjectilInimigo, Quaternion.identity);
                    cooldownProjectil = 20;
                }
                
            }
            else  
            {
                animator.Play("ANIM_Enemy_2_Idle");
                for (int s = 0; s < olhosInimigo.Length; s++)
                {
                    olhosInimigo[s].color = Color.white;
                }
            }
        }
    }

    public void InimigoReceberDano()
    {
        //inimigo morreu
        if (vidaAtualInimigo <= 0)
        {
            inimigoMorto = true;
            corpoInimigo.color = Color.magenta;
            animator.Play("ANIM_Enemy_2_Death");
            StartCoroutine(DelayDeath());

        }

        //inimigo sofreu dano, mas nao morreu

        else if (Projectil.atingiInimigo == true)
        {
           
          corpoInimigo.DOColor(corFlashCorpoInimigo, 0.2f).SetLoops(2, LoopType.Yoyo);
            
            Projectil.atingiInimigo = false;
            
        }

    }
    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(2f);

        Destroy(inimigo);
    }

}
