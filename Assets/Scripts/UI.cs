using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static int qtdMoedas;
    public TextMeshProUGUI qtdMoedasText;
    // Start is called before the first frame update
    void Start()
    {
        qtdMoedas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        qtdMoedasText.text = "" + qtdMoedas;
    }
}
