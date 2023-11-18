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

    public GameObject animatorHolder;

    int next_sv_pos = 0;
    int next_ex_pos = 0;

    bool second_page = true;

    int current_page = 0;

    public void calcularResultado()
    {
        bool flawless = true;
        for (int i = 0; i < pranchetaManager.selecionados.Count; i++) //confere os erros e acertos
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

        bool emptyExames = true;
        bool emptySinais = true;
        for (int i = 0; i < ST.Count; i++) //os dois 'for' abaixo conferem se há páginas vazias
        {
            if (ST[i].GetComponent<TextMeshProUGUI>().text != "")
            {
                emptySinais = false;
            }
        }
        for (int j = 0; j < ET.Count; j++)
        {
            if (ET[j].GetComponent<TextMeshProUGUI>().text != "")
            {
                emptyExames = false;
            }
        }

        if (emptySinais) //adiciona o marcador de página vazia
        {
            ST[0].GetComponent<TextMeshProUGUI>().text = "- página vazia.";
        }
        else if (emptyExames)
        {
            second_page = false;
            //ET[0].GetComponent<TextMeshProUGUI>().text = "- página vazia.";
        }

        if (second_page == true)
        {
            animatorHolder.GetComponent<Animator>().Play("pulse");
        }
        

        if (flawless) //determina se o jogador ganhou ou não uma estrela na fase
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

    void adicionarFeedback(int index, string type) //adiciona os textos de feedback aos respectivos espaços reservados
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
            ST[next_sv_pos].GetComponent<TextMeshProUGUI>().text = textos[index] + " " + pranchetaManager.Lab[index - 10];
            SL[next_sv_pos].GetComponent<TextMeshProUGUI>().text = type;
            next_sv_pos++;
        }
    }

    public void showSinais()
    {
        if (current_page == 1)
        {
            SinaisTexts.SetActive(true);
            SinaisLabel.SetActive(true);
            ExameTexts.SetActive(false);
            ExameLabel.SetActive(false);
            current_page = 0;
        }
        else if (second_page == true)
        {
            SinaisTexts.SetActive(false);
            SinaisLabel.SetActive(false);
            ExameTexts.SetActive(true);
            ExameLabel.SetActive(true);
            current_page = 1;
        }
    }

    public void showExames()
    {
        if(second_page == true && current_page == 0) 
        {
            SinaisTexts.SetActive(false);
            SinaisLabel.SetActive(false);
            ExameTexts.SetActive(true);
            ExameLabel.SetActive(true);
            current_page = 1;
        }
        else if (second_page == true)
        {
            SinaisTexts.SetActive(true);
            SinaisLabel.SetActive(true);
            ExameTexts.SetActive(false);
            ExameLabel.SetActive(false);
            current_page = 0;
        }
    }
}
