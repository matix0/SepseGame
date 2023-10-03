using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackCasoModal : MonoBehaviour
{
    SelecionarNiveisManager niveisManager;
    public string txt_feedback;
    // Start is called before the first frame update

    public void Start()
    {
        getFeedback();
    }
    public string getFeedback() {
        switch (niveisManager.numeroNivel)
        {
            default:
                break;
            case 1:
                txt_feedback = "" +
                    "\n1) Verificar e avaliar press�o arterial sist�mica, pulso, temperatura axilar, frequ�ncia respirat�ria, expansibilidade tor�cica de 2 em 2 horas." +
                    "\n2) Avaliar a intensidade da dor." +
                    "\n3) Puncionar acesso venoso perif�rico." +
                    "\n4) Administrar analg�sico e antit�rmico endovenosos conforme prescri��o m�dica." +
                    "\n5) Monitorar n�vel de consci�ncia da paciente a cada 2 horas." +
                    "\n6) Postergar administra��o de antimicrobianos at� defini��o do quadro infecioso da paciente pela equipe m�dica.";
                break;
        }
        return txt_feedback;
    }
}
