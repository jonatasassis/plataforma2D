using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cenas : MonoBehaviour
{
    public int idCena;
    // Start is called before the first frame update
    

    public void FecharJogo()
    {
        Application.Quit();
    }

    public void TrocarCena() 
    {
        SceneManager.LoadScene(idCena);
    }
}
