using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectil : MonoBehaviour
{
  
    public Rigidbody2D projectilRigidbody2D;
    public int danoProjectil,velocidadeProjectil,duracaoProjectil;
    public Vector2 direcao,posicaoInicialProjectil;
    public GameObject projectil;
    public bool flipDirecaoProjectil=false,projectilInimigo,projectilPlayer;
    
    public static bool atingiPlayer=false,atingiInimigo=false;
    

    // Start is called before the first frame update
    void Start()
    {
       
        duracaoProjectil = 30;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flipDirecaoProjectil)
        {
            projectilRigidbody2D.velocity = new Vector2(velocidadeProjectil, projectilRigidbody2D.velocity.y);
        }
        else 
        {
            projectilRigidbody2D.velocity = new Vector2(-velocidadeProjectil, projectilRigidbody2D.velocity.y);
        }
        
        if (duracaoProjectil > 0)
        {
            duracaoProjectil--;
        }

        else if (duracaoProjectil <= 0)
        {
            Destroy(projectil);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& projectilInimigo)
        {
            atingiPlayer = true;
            Personagem.vidaAtual = Personagem.vidaAtual - danoProjectil;
            Destroy(projectil);
            print("player atingido. vida atual: " + Personagem.vidaAtual);

        }

        else if (collision.tag == "Inimigo" && projectilPlayer)
        {
            atingiInimigo = true;
            Inimigo.vidaAtualInimigo = Inimigo.vidaAtualInimigo - danoProjectil;
            Destroy(projectil);
            print("Inimigo atingido. vida atual: " + Inimigo.vidaAtualInimigo);


        }
    }
}
