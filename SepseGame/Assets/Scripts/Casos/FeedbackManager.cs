using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public List<int> corretas;
    public List<string> textos;

    public FeedbackCondutas feedbackCondutas;
    public Caso1 generalManager;
    public GameObject warnIcon, successIcon;
    public GameObject feedbackCell;
    public GameObject ResultGrid;
    public PranchetaManager pranchetaManager;
    public GameObject stars;
    public Animator starsAnimator;
    
    public int estrelas;

    int erros; //informações que o jogador marcou incorretamente
    int falhas; //informações que o jogador deixou de marcar

    bool screenshotTaken = false;

    public void gerarFeedback() //contabiliza os erros e falhas para determinar o número de estrelas e tocar a animação correspondente
    {
        for (int i = 0; i < pranchetaManager.selecionados.Count; i++)
        {
            if (!corretas.Contains(pranchetaManager.selecionados[i]))
            {
                erros++;
                //adicionarErro(pranchetaManager.selecionados[i]);
            }
        }
        for (int j = 0; j < corretas.Count; j++)
        {
            if (!pranchetaManager.selecionados.Contains(corretas[j]))
            {
                falhas++;
            }
        }
        /*
        if (falhas > 0)
        {
            //adicionarFalhas(falhas);
        }

        if (feedbackCondutas.errosCondutas > 0)
        {
            //adicionarCondutas();
        }*/

        erros += falhas;

        if (erros == 0 & falhas == 0 & feedbackCondutas.errosCondutas <= 0)
        {
            estrelas = 3;
            stars.GetComponent<Animator>().Play("threeStars");
        }
        else if (erros == 0 & falhas == 0)//erros <= corretas.Count/2
        {
            estrelas = 2;
            stars.GetComponent<Animator>().Play("twoStars");
        }
        else
        {
            estrelas = 1;
            stars.GetComponent<Animator>().Play("oneStar");
        }
    }

    void adicionarErro(int index) //adiciona uma FeedbackCell (Prefab) contendo a explicação de um erro do jogador
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        string s = textos[index] + " ";
        if (index <= 4)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + pranchetaManager.SinaisVitais[index] + " não caracteriza SIRS.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + " não caracterizou Disfunção Orgânica.";
        }
    }

    void adicionarFalhas(int amount) //adiciona uma FeedbackCell (Prefab) contendo a explicação de uma falha do jogador
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

    void adicionarCondutas()
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        cell.GetComponent<TextMeshProUGUI>().text = "As Condutas não foram ordenadas corretamente.";
    }

    private void Update()
    {
        /*//detecta se a animação foi finalizada antes de tirar a screenshot da tela
        AnimatorClipInfo[] currentClip = starsAnimator.GetCurrentAnimatorClipInfo(0);
        if (currentClip[0].clip.name.Contains("slide_up"))
        {
            if(starsAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > starsAnimator.GetCurrentAnimatorStateInfo(0).length)
            {
                ScreenCapture.CaptureScreenshot("FeedbackCaso" + generalManager.Caso.ToString() + ".png");
                screenshotTaken = true;
            }
        }*/
    }
}
