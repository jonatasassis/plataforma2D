using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int vidaInicial;
    private int vidaAtual;
    private bool estouMorto=false;
    public bool destruirObjeto = false;
    public float delayDestruirObjeto = 0.1f;
    public GameObject novoPlayer,playerAtual;
    public Vector3 posicaoRespawn;
    public CinemachineVirtualCamera virtualCam;
  
  

    private void Awake()
    {
        vidaAtual = vidaInicial;
        posicaoRespawn= playerAtual.transform.position;

        
    }

    private void Update()
    {
        virtualCam.LookAt = playerAtual.transform;
        virtualCam.Follow = playerAtual.transform;
        
    }
    public void Dano(int dano)
    {
        if (estouMorto)
            return;
        vidaAtual = vidaAtual - dano;
        if (vidaAtual <= 0)
        {
            Morri();
        }

        

        
    }

    private void Morri()
    {
        estouMorto = true;
       
        if (destruirObjeto)
        {
           
            Destroy(gameObject,delayDestruirObjeto);
           
        }

            Instantiate(novoPlayer, posicaoRespawn, Quaternion.Euler(0,0,0));
            playerAtual = novoPlayer;
        
            
    }

   
}
