using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text1Handler : MonoBehaviour
{
    int currentPosition;
    string fullText = "Voc� ser� o (a) enfermeiro (a) que est� de plant�o na unidade de emerg�ncia e dever� avaliar cada paciente admitido. O desafio de hoje � reconhecer os casos confirmados ou suspeitos de sepse e com base na presen�a de disfun��o org�nica ou crit�rios de s�ndrome de resposta inflamat�ria sist�mica (SRIS) dever� tomar decis�es acerca da abertura  ou n�o do protocolo de sepse, chamar ou n�o a equipe m�dica, iniciar ou n�o o pacote de primeira hora para o tratamento de casos suspeitos, priorizar as condutas de enfermagem necess�rias para cada caso cl�nico. Sua tomada de decis�o permitir� que voc� avance no jogo. Utilize o sistema de clicks para ativar os di�logos, as tomadas de decis�es e as a��es. Condutas corretas permitir� que voc� acumule pontos, caso contr�rio perder� pontos. No total h� 13 casos cl�nicos para serem solucionados. No final de cada caso, voc� ter� um feedback de sua performance.  Aparecer� uma janela mostrando o seu desempenho.  Boa sorte!";
    float Delay = 0.04f;
    public GameObject T1;

    private void OnEnable()
    {
        StartCoroutine(showText());
    }

    IEnumerator showText()
    {
        while (currentPosition < fullText.Length)
        {
            T1.GetComponent<TextMeshProUGUI>().text += fullText[currentPosition++];
            yield return new WaitForSeconds(Delay);
        }
    }
}
