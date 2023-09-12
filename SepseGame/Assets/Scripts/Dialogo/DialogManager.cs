using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public string Paciente1, Paciente2;

    public GameObject BalaoPaciente, BalaoNurse;
    public GameObject buttonContinuar;

    int currentPosition = 0;
    float Delay = 0.04f;
    private string fullText = "";
    private string fullText2 = "";

    public void loadTexts(int index) //prepara os textos nos GameObjects para serem mostrados pela função showTexts()
    {
        currentPosition = 0;
        buttonContinuar.SetActive(false);
        BalaoNurse.GetComponent<TextMeshProUGUI>().text = "";
        BalaoPaciente.GetComponent<TextMeshProUGUI>().text = "";

        if (index == 0)
        {
            fullText = Paciente1;
            fullText2 = "O que você está sentindo neste momento?";
        }
        else
        {
            fullText = Paciente2;
            fullText2 = "O que motivou sua busca por atendimento médico?";
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
