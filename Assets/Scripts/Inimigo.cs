using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int danoInimigo=10,distanciaXPlayerInimigo,areaAtaqueInimigo,x,y, cooldownProjectil,vidaInicialInimigo;
    public Personagem personagem;
    public GameObject projectilInimigo,inimigo, bocaAberta;
    public Vector2 posInicialProjectilInimigo;
    public SpriteRenderer[] olhosInimigo;
    public SpriteRenderer corpoInimigo;
    public Color corFlashOlhosInimigos,corFlashCorpoInimigo;
    public static int vidaAtualInimigo;
     

    private void Awake()
    {
        bocaAberta.SetActive(false);
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
        if (cooldownProjectil > 0)
        {
            cooldownProjectil--;

        }
        distanciaXPlayerInimigo = (int)inimigo.transform.position.x - (int)personagem.transform.position.x;
        if (distanciaXPlayerInimigo < areaAtaqueInimigo && cooldownProjectil == 0)
        {
            bocaAberta.SetActive(true);
            Instantiate(projectilInimigo, posInicialProjectilInimigo, Quaternion.identity);
            cooldownProjectil = 20;

            for (int s = 0; s < olhosInimigo.Length; s++)
            {
                olhosInimigo[s].color = corFlashOlhosInimigos;
            }
        }
        else if (distanciaXPlayerInimigo > areaAtaqueInimigo)
        {
            bocaAberta.SetActive(false);
            for (int s = 0; s < olhosInimigo.Length; s++)
            {
                olhosInimigo[s].color = Color.white;
            }
        }
    }

    public void InimigoReceberDano()
    {
        //inimigo morreu
        if (vidaAtualInimigo <= 0)
        {
            Destroy(inimigo);



        }

        //inimigo sofreu dano, mas nao morreu

        else if (Projectil.atingiInimigo == true)
        {
           
          corpoInimigo.DOColor(corFlashCorpoInimigo, 0.2f).SetLoops(2, LoopType.Yoyo);
            
            Projectil.atingiInimigo = false;
            
        }

    }

    
}
