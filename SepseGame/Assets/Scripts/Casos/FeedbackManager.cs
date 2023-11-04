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

    int erros; //informa��es que o jogador marcou incorretamente
    int falhas; //informa��es que o jogador deixou de marcar

    bool screenshotTaken = false;

    public void gerarFeedback() //contabiliza os erros e falhas para determinar o n�mero de estrelas e tocar a anima��o correspondente
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

    void adicionarErro(int index) //adiciona uma FeedbackCell (Prefab) contendo a explica��o de um erro do jogador
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        string s = textos[index] + " ";
        if (index <= 4)
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + pranchetaManager.SinaisVitais[index] + " n�o caracteriza SIRS.";
        }
        else
        {
            cell.GetComponent<TextMeshProUGUI>().text = "- " + s + " n�o caracterizou Disfun��o Org�nica.";
        }
    }

    void adicionarFalhas(int amount) //adiciona uma FeedbackCell (Prefab) contendo a explica��o de uma falha do jogador
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

    void adicionarCondutas()
    {
        GameObject cell;
        cell = Instantiate(feedbackCell, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cell.transform.parent = ResultGrid.transform;
        cell.GetComponent<TextMeshProUGUI>().text = "As Condutas n�o foram ordenadas corretamente.";
    }

    private void Update()
    {
        /*//detecta se a anima��o foi finalizada antes de tirar a screenshot da tela
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
