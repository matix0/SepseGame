using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text2Handler : MonoBehaviour
{
    int currentPosition;
    string fullText = "Sua tomada de decis�o permitir� que voc� avance no jogo. Utilize o sistema de clicks para ativar os di�logos, as tomadas de decis�es e as a��es. Condutas corretas permitir�o que voc� acumule pontos, caso contr�rio perder� pontos. No total h� 13 casos cl�nicos para serem solucionados. No final de cada caso, voc� ter� um feedback de sua performance. Aparecer� uma janela mostrando o seu desempenho. Boa sorte!";
    float Delay = 0.04f;
    public GameObject T2;

    private void OnEnable()
    {
        StartCoroutine(showText());
    }

    IEnumerator showText()
    {
        while (currentPosition < fullText.Length)
        {
            T2.GetComponent<TextMeshProUGUI>().text += fullText[currentPosition++];
            yield return new WaitForSeconds(Delay);
        }
    }
}
