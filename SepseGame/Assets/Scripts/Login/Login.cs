using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public static string nome = "defaultName";
    public static string cpf = "12345678910";
    public GameObject inputFieldNome;
    public GameObject inputFieldCpf;
    public GameObject PlaceHolderNome;
    public GameObject PlaceHolderCpf;
    public bool permited = false;

    public NiveisConcluidos niveisConcluidos;

    private void Start()
    {
        ResetarProgresso();
    }

    public void ReceberNome()
    {
        nome = inputFieldNome.GetComponent<TextMeshProUGUI>().text;
        
    }
    public void ReceberCpf()
    {
        cpf = inputFieldCpf.GetComponent<TextMeshProUGUI>().text;
    }

    [System.Obsolete]
    public void ProxScene()
    {
        if (nome != "defaultName")
        {
            permited = true;
        }
        else
        {
            permited = false;
            PlaceHolderNome.GetComponent<TextMeshProUGUI>().text = "O nome ainda n�o foi inserido!";
            PlaceHolderNome.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        if(permited)
        {
            if (cpf != "12345678910")
            {
                permited = true;
            }
            else
            {
                permited = false;
                PlaceHolderCpf.GetComponent<TextMeshProUGUI>().text = "O CPF ainda n�o foi inserido";
                PlaceHolderCpf.GetComponent<TextMeshProUGUI>().color = Color.red;
            }
        }
        if (permited)
        {
            ReceberNome();
            ReceberCpf();
            Application.LoadLevel("TextoInicial");
        }
    }
    public void ResetarProgresso()
    {
        for (int i = 0; i < 14; i++)
        {
            PlayerPrefs.SetInt("caso" + i.ToString(), 0);
        }
        for (int i = 0; i < 13; i++)
        {
            niveisConcluidos.casos[i] = false;
        }
        Debug.Log("Progresso apagado!!");
        niveisConcluidos.emailEnviado = false;
    }
}
