using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    public HP personagem;
    public Rigidbody2D projectilRigidbody2D;
    public int danoProjectil,velocidadeProjectil,duracaoProjectil;
    public string alvo;
    public Vector2 direcao;
    public GameObject projectil;
    // Start is called before the first frame update
    void Start()
    {
        duracaoProjectil = 90;
    }

    // Update is called once per frame
    void Update()
    {

        projectilRigidbody2D.velocity = new Vector2(-velocidadeProjectil, projectilRigidbody2D.velocity.y);
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
        if (collision.tag == alvo)
        {
            personagem.Dano(danoProjectil);
            Destroy(projectil);
            print("player atingido");
        }
    }
}
