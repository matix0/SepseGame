using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text2Handler : MonoBehaviour
{
    int currentPosition;
    string fullText = "No jogo, suas decis�es impulsionar�o seu progresso. Utilize os cliques do mouse para ativar as tomadas de decis�es e a��es. Condutas corretas resultam em estrelas acumuladas. No total s�o 13 casos cl�nicos para serem solucionados. Estes est�o divididos em 06 casos de baixa complexidade e 07 de m�dia complexidade. No final de cada caso voc� receber� um feedback sobre sua performance em uma tela, indicando o n�mero de estrelas conquistadas. Para o trof�u final, � necess�rio que voc� acumule 39 estrelas.";
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
