using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public float tempoTransicaoAudioMixer;
    public Slider slider;
    public AudioMixerSnapshot audioMixerSnapshot;
    public string parametro;
    public AudioMixer audioMixer;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void MutarVolume()
    {
        audioMixerSnapshot.TransitionTo(tempoTransicaoAudioMixer);
    }

    public void ControleVolume()
    {
        audioMixer.SetFloat(parametro,slider.value);
    }

}
