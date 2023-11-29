using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public   SOInt qtdMoedas;
    public TextMeshProUGUI qtdMoedasText;
    // Start is called before the first frame update
    void Start()
    {
        
        qtdMoedas.valorInt = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Coletaveis.coletei)
        {
            qtdMoedas.valorInt++;
            Coletaveis.coletei = false;
        }
        qtdMoedasText.text = "" + qtdMoedas.valorInt;
    }
}
