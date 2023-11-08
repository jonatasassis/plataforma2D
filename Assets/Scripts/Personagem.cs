using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public int velocidadeCaminhada,velocidadeCorrida,velocidadeAtual,forcaPulo;
    public Vector2 friccao = new Vector2(1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Pulo();
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
        }
        
    }
}
