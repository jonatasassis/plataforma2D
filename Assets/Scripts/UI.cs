using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public   SOInt qtdMoedasRoxas,qtdMoedasVerde;
    public TextMeshProUGUI qtdMoedasRoxasText,qtdMoedasVerdeText;
    // Start is called before the first frame update
    void Start()
    {
        
        qtdMoedasRoxas.valorInt = 0;
        qtdMoedasVerde.valorInt = 0;
        
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
}
