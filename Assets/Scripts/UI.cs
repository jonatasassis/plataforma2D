using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public   SOInt qtdMoedasRoxas,qtdMoedasVerde;
    public TextMeshProUGUI qtdMoedasRoxasText,qtdMoedasVerdeText;
    public GameObject painelConfig,telaInicial;
    
   
    
   
    // Start is called before the first frame update
    void Start()
    {
        telaInicial.SetActive(true);
        qtdMoedasRoxas.valorInt = 0;
        qtdMoedasVerde.valorInt = 0;
        painelConfig.SetActive(false);
        
        Time.timeScale= 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Coletaveis.coleteiMoedaRoxa)
        {
            qtdMoedasRoxas.valorInt++;
            Coletaveis.coleteiMoedaRoxa = false;
        }
        else if (Coletaveis.coleteiMoedaVerde)
        {
            qtdMoedasVerde.valorInt++;
            Coletaveis.coleteiMoedaVerde = false;
        }
        qtdMoedasVerdeText.text = "" + qtdMoedasVerde.valorInt;
        qtdMoedasRoxasText.text = "" + qtdMoedasRoxas.valorInt;
    }

    public void AbrirPainelConfig()
    {
        painelConfig.SetActive (true);
        Time.timeScale = 0f;
    }
    public void FecharPainelConfig()
    {
        painelConfig.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void FecharTelaInicial()
    {
        telaInicial.SetActive(false);
        Time.timeScale = 1.0f;
    }
  
    

}
