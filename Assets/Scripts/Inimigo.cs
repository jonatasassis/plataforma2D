using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int danoInimigo=10,distanciaXPlayerInimigo,areaAtaqueInimigo,x,y,cooldownProjectil;
    public Personagem personagem;
    public GameObject projetilInimigo,inimigo,mira;
    

    private void Update()
    {
        if(cooldownProjectil>0)
        {
            cooldownProjectil--;

        }
       distanciaXPlayerInimigo= (int)inimigo.transform.position.x-(int)personagem.transform.position.x;
        if (distanciaXPlayerInimigo < areaAtaqueInimigo&& cooldownProjectil<=0 )
        {
            
            Instantiate(projetilInimigo,new Vector2(mira.transform.position.x,mira.transform.position.y),Quaternion.identity);
            cooldownProjectil = 20;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        var hp = col.gameObject.GetComponent<HP>();

        if (hp != null)
        {
            hp.Dano(danoInimigo);
        }
    }
}
