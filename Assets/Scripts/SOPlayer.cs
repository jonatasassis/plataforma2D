using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    [Header("infos player")]
    public int vidaInicial;
    public Vector3 posicaoRespawnPlayer;

    [Header("movimentacao")]
    public int velocidadeCaminhada, velocidadeCorrida, velocidadeAtual, forcaPulo;
    public Vector2 friccao = new Vector2(1f, 0);

    [Header("animacao")]
    public float stretchY;
    public float stretchX;
    public float duracaoAnimacao;
    public Ease ease = Ease.OutBack;
    public Color corFlash;
    public float duracaoFlash = 0.2f;


}

