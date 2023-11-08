using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Singleton
{
public class Singleton<P> : MonoBehaviour where P : MonoBehaviour
{
    public static P Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<P>() ;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
}