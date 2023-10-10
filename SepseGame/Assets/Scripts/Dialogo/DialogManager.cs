using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public string Paciente1, Paciente2;

    public GameObject BalaoPaciente, BalaoNurse;
    public GameObject buttonContinuar;

    public Caso1 generalManager;

    public int currentDialog = 0; //default 0

    int currentPosition = 0;
    float Delay = 0.03f;
    private string fullText = "";
    private string fullText2 = "";

    public void loadTexts(int index) //prepara os textos nos GameObjects para serem mostrados pela fun��o showTexts()
    {
        currentDialog = index;
        currentPosition = 0;
        buttonContinuar.SetActive(false);
        BalaoNurse.GetComponent<TextMeshProUGUI>().text = "";
        BalaoPaciente.GetComponent<TextMeshProUGUI>().text = "";

        if (index == 0)
        {
            fullText = Paciente1;
            if (generalManager.sexo)
            {
                fullText2 = "O que o senhor est� sentindo neste momento?";
            }
            else
            {
                fullText2 = "O que a senhora est� sentindo neste momento?";
            }
        }
        else if (index == 1)
        {
            fullText = Paciente2;
            if (generalManager.sexo)
            {
                fullText2 = "O que motivou o senhor a procurar por atendimento neste servi�o de sa�de ?";
            }
            else
            {
                fullText2 = "O que motivou a senhora a procurar por atendimento neste servi�o de sa�de ?";
            }
        }
        else
        {
            fullText = "";
            if (generalManager.sexo)
            {
                fullText2 = "Certo. Vou avaliar o senhor agora e ver como posso ajud�-lo.";
            }
            else
            {
                fullText2 = "Certo. Vou avaliar a senhora agora e ver como posso ajud�-la.";
            }
        }
        StartCoroutine(showTexts());
    }

    IEnumerator showTexts() //revela o texto letra por letra
    {
        while (currentPosition < fullText2.Length)
        {
            BalaoNurse.GetComponent<TextMeshProUGUI>().text += fullText2[currentPosition++];
            yield return new WaitForSeconds(Delay);
        }

        currentPosition = 0;

        while (currentPosition < fullText.Length)
        {
            BalaoPaciente.GetComponent<TextMeshProUGUI>().text += fullText[currentPosition++];
            yield return new WaitForSeconds(Delay);
        }

        buttonContinuar.SetActive(true);
    }
}

