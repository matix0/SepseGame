using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackHospital : MonoBehaviour
{
    public List<int> corretas;
    public List<string> textos;

    public GameObject SinaisTexts, SinaisLabel, ExameTexts, ExameLabel;
    public List<GameObject> ET, EL, ST, SL;

    public Caso1 generalManager;
    public PranchetaManager pranchetaManager;
    public GameObject resultText;
    public GameObject star, starText;

    int next_sv_pos = 0;
    int next_ex_pos = 0;

    public void calcularResultado()
    {
        bool flawless = true;
        for (int i = 0; i < pranchetaManager.selecionados.Count; i++)
        {
            if (!corretas.Contains(pranchetaManager.selecionados[i]))
            {
                adicionarFeedback(pranchetaManager.selecionados[i], "- ERRADO.");
                flawless = false;
            }
            else
            {
                adicionarFeedback(pranchetaManager.selecionados[i], "- CERTO.");
            }
        }
        for (int j = 0; j < corretas.Count; j++)
        {
            if (!pranchetaManager.selecionados.Contains(corretas[j]))
            {
                adicionarFeedback(corretas[j], "- NÃO MARCOU.");
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

    void adicionarFeedback(int index, string type)
    {
        if (index <= 4)
        {
            ST[next_sv_pos].GetComponent<TextMeshProUGUI>().text = textos[index] + " " + pranchetaManager.SinaisVitais[index];
            SL[next_sv_pos].GetComponent<TextMeshProUGUI>().text = type;
            next_sv_pos++;
        }
        else if (index > 4 & index <= 9)
        {
            ET[next_ex_pos].GetComponent<TextMeshProUGUI>().text = textos[index] + " " + pranchetaManager.SinaisVitais[index];
            EL[next_ex_pos].GetComponent<TextMeshProUGUI>().text = type;
            next_ex_pos++;
        }
        else
        {
            ST[next_sv_pos].GetComponent<TextMeshProUGUI>().text = textos[index] + " " + pranchetaManager.Lab[index];
            SL[next_sv_pos].GetComponent<TextMeshProUGUI>().text = type;
            next_sv_pos++;
        }
    }

    public void showSinais()
    {
        SinaisTexts.SetActive(true);
        SinaisLabel.SetActive(true);
        ExameTexts.SetActive(false);
        ExameLabel.SetActive(false);
    }

    public void showExames()
    {
        SinaisTexts.SetActive(false);
        SinaisLabel.SetActive(false);
        ExameTexts.SetActive(true);
        ExameLabel.SetActive(true);
    }
}
