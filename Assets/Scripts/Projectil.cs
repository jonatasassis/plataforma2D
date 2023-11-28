using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectil : MonoBehaviour
{
  
    public Rigidbody2D projectilRigidbody2D;
    public int danoProjectil,velocidadeProjectil,duracaoProjectil;
    public string alvo;
    public Vector2 direcao,posicaoInicialProjectil;
    public GameObject projectil;
    public SpriteRenderer []spritePlayer;
    
    public static bool atingiPlayer=false;
    

    // Start is called before the first frame update
    void Start()
    {
       
        duracaoProjectil = 30;
        
    }

    // Update is called once per frame
    void Update()
    {

        projectilRigidbody2D.velocity = new Vector2(-velocidadeProjectil, projectilRigidbody2D.velocity.y);
        if (duracaoProjectil > 0)
        {
            duracaoProjectil--;
        }

        /*else if (duracaoProjectil <= 0)
        {
            Destroy(projectil);
            
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == alvo)
        {
            atingiPlayer = true;
            Personagem.vidaAtual=Personagem.vidaAtual-danoProjectil;
            Destroy(projectil);
            print("player atingido. vida atual: "+Personagem.vidaAtual);
            
        }
    }
}
