using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabensBools : MonoBehaviour
{
    public bool casosBasicos = false;
    public bool casosAvancados = false;
    public bool jogoConcluido = false;

    public bool emailEnviado = false;

    public int ultimoNivelJogado = 0;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("parabens");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
