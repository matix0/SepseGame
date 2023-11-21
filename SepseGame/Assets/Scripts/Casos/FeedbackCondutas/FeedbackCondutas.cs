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

    public GameObject star, starText;

    public Color Acerto, Erro;

    public int errosCondutas = 0;

    public void generateFeedback()
    {
        bool flawless = true;
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
                errosCondutas++;
                flawless = false;
            }
        }
        if (flawless)
        {
            star.SetActive(true);
            starText.GetComponent<TextMeshProUGUI>().text = "Parabéns! Acertou tudo, ganhou uma estrela!";
        }
        else
        {
            star.SetActive(false);
            starText.GetComponent<TextMeshProUGUI>().text = "Infelizmente você não obteve uma estrela, mas não desanime! Tente novamente!";
        }
    }

    public void goNext()
    {
        SceneManager.LoadScene("Pontuacao");
    }
}
