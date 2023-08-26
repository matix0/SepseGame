using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FeedbackCondutas : MonoBehaviour
{
    public Pacote CondutasScript;

    public List<GameObject> txtCorretas;
    public List<GameObject> txtMarcadas;

    public Estetica pack;

    public Color Acerto, Erro;

    void Start()
    {
        for (int i=0; i < txtCorretas.Count; i++)
        {
            txtCorretas[i].GetComponentInChildren<TextMeshProUGUI>().text = CondutasScript.condutas[i];
            txtMarcadas[i].GetComponentInChildren<TextMeshProUGUI>().text = CondutasScript.condutas[CondutasScript.selecaoCondutas[i]];

            if (CondutasScript.condutas[i] == CondutasScript.condutas[CondutasScript.selecaoCondutas[i]])
            {
                txtMarcadas[i].GetComponent<Image>().color = Acerto;
            }
            else
            {
                txtMarcadas[i].GetComponent<Image>().color = Erro;
            }
        }
    }

    public void goNext()
    {
        SceneManager.LoadScene("Pontuacao");
    }
}
