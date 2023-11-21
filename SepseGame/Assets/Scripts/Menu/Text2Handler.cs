using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text2Handler : MonoBehaviour
{
    int currentPosition;
    string fullText = "No jogo, suas decisões impulsionarão seu progresso. Utilize os cliques do mouse para ativar as tomadas de decisões e ações. Condutas corretas resultam em estrelas acumuladas. No total são 13 casos clínicos para serem solucionados. Estes estão divididos em 06 casos de baixa complexidade e 07 de média complexidade. No final de cada caso você receberá um feedback sobre sua performance em uma tela, indicando o número de estrelas conquistadas. Para o troféu final, é necessário que você acumule 39 estrelas.";
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
