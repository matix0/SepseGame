using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public List<int> corretas;
    public List<string> textos;

    public Caso1 generalManager;
    public GameObject warnIcon, successIcon;
    public GameObject feedbackCell;
    public GameObject ResultGrid;
    public PranchetaManager pranchetaManager;
    public GameObject stars;

    public int estrelas;

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

        erros += falhas;

        if (erros == 0 & falhas == 0)
        {
            estrelas = 3;
            stars.GetComponent<Animator>().Play("threeStars");
        }
        else if(erros <= corretas.Count/2)
        {
            estrelas = 2;
            stars.GetComponent<Animator>().Play("twoStars");
        }
        else
        {
            estrelas = 1;
            stars.GetComponent<Animator>().Play("oneStar");
        }

        ScreenCapture.CaptureScreenshot("FeedbackCaso" + generalManager.Caso.ToString() + ".png");
    }

    void adicionarErro(int index)
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        string s = pranchetaManager.texts[index].text;
        if(index <= 4)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + " não caracteriza SIRS.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + textos[index] + " não caracterizou Disfunção Orgânica.";
        }
    }

    void adicionarFalhas(int amount)
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        if (amount == 1)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "Um critério não foi marcado como SIRS ou Disfunção Orgânica.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = falhas.ToString() + " critérios não foram marcados como SIRS ou Disfunção Orgânica.";
        }
    }
}
