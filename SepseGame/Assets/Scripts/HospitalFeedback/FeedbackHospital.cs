using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackHospital : MonoBehaviour
{
    public List<int> corretas;
    public List<string> textos;

    public Caso1 generalManager;
    public PranchetaManager pranchetaManager;
    public GameObject resultText;
    public GameObject star, starText;

    public void calcularResultado()
    {
        bool flawless = true;
        for (int i = 0; i < pranchetaManager.selecionados.Count; i++)
        {
            if (!corretas.Contains(pranchetaManager.selecionados[i]))
            {
                adicionarErro(pranchetaManager.selecionados[i]);
                flawless = false;
            }
            else
            {
                adicionarAcerto(pranchetaManager.selecionados[i]);
            }
        }
        for (int j = 0; j < corretas.Count; j++)
        {
            if (!pranchetaManager.selecionados.Contains(corretas[j]))
            {
                adicionarFalha(corretas[j]);
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
            starText.GetComponent<TextMeshProUGUI>().text = "Infelizmente você cometeu erros, mas não desanime! Tente novamente para tentar ganhar uma estrela!";
        }
    }

    void adicionarErro(int index)
    {
        resultText.GetComponent<TextMeshProUGUI>().text += "\n- " + textos[index] + " " + pranchetaManager.SinaisVitais[index] + " - ERRADO.";
    }

    void adicionarAcerto(int index)
    {
        resultText.GetComponent<TextMeshProUGUI>().text += "\n- " + textos[index] + " " + pranchetaManager.SinaisVitais[index] + " - CERTO!";
    }

    void adicionarFalha(int index)
    {
        resultText.GetComponent<TextMeshProUGUI>().text += "\n- " + textos[index] + " " + pranchetaManager.SinaisVitais[index] + " - NÃO MARCOU.";
    }
}
