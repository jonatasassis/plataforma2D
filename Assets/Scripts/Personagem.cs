using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;
    public int velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody2D.velocity= new Vector2(velocidade,myRigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody2D.velocity = new Vector2(-velocidade, myRigidbody2D.velocity.y);
        }
    }
}
