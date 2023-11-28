using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int danoInimigo=10,distanciaXPlayerInimigo,areaAtaqueInimigo,x,y,cooldownProjectil;
    public Personagem personagem;
    public GameObject projectilInimigo,inimigo, bocaAberta;
    public Vector2 posInicialProjectilInimigo;
    public SpriteRenderer[] olhosInimigo;
    public Color corFlashOlhosInimigos;
     

    private void Awake()
    {
        bocaAberta.SetActive(false);
    }
    private void Update()
    {
        if(cooldownProjectil>0)
        {
            cooldownProjectil--;

        }
       distanciaXPlayerInimigo= (int)inimigo.transform.position.x-(int)personagem.transform.position.x;
        if (distanciaXPlayerInimigo < areaAtaqueInimigo && cooldownProjectil == 0)
        {
            bocaAberta.SetActive(true);
            Instantiate(projectilInimigo, posInicialProjectilInimigo, Quaternion.identity);
            cooldownProjectil = 20;

            for (int s = 0; s < olhosInimigo.Length; s++)
            {
                olhosInimigo[s].color=corFlashOlhosInimigos;
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
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Personagem.vidaAtual = 0;
               
            }
        }
    
}
