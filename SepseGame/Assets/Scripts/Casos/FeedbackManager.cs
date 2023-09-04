using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public List<int> corretas;
    public List<string> textos;

    public GameObject warnIcon, successIcon;
    public GameObject feedbackCell;
    public GameObject ResultGrid;
    public PranchetaManager pranchetaManager;
    public GameObject stars;

    int erros;
    int falhas;

    public void gerarFeedback()
    {
        for (int i=0; i < pranchetaManager.selecionados.Count; i++)
        {
            if (!corretas.Contains(pranchetaManager.selecionados[i]))
            {
                erros++;
                adicionarErro(i);
            }
        }
        for (int j=0; j < corretas.Count; j++)
        {
            if (!pranchetaManager.selecionados.Contains(corretas[j]))
            {
                falhas++;
            }
        }
        if(falhas > 0)
        {
            adicionarFalhas(falhas);
        }

        erros = erros + falhas;

        if (erros == 0 & falhas == 0)
        {
            stars.GetComponent<Animator>().Play("threeStars");
            warnIcon.SetActive(false);
        }
        else if(erros <= corretas.Count/2)
        {
            stars.GetComponent<Animator>().Play("twoStars");
        }
        else
        {
            stars.GetComponent<Animator>().Play("oneStar");
        }
    }

    void adicionarErro(int index)
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        string s = pranchetaManager.texts[index].text;
        if(index <= 4)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + " n�o caracteriza SIRS.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + textos[index] + " n�o caracterizou Disfun��o Org�nica.";
        }
    }

    void adicionarFalhas(int amount)
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        if (amount == 1)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "Um crit�rio n�o foi marcado como SIRS ou Disfun��o Org�nica.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = falhas.ToString() + " crit�rios n�o foram marcados como SIRS ou Disfun��o Org�nica.";
        }
    }
}
