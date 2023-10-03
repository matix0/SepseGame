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
                    "\n1) Verificar e avaliar pressão arterial sistêmica, pulso, temperatura axilar, frequência respiratória, expansibilidade torácica de 2 em 2 horas." +
                    "\n2) Avaliar a intensidade da dor." +
                    "\n3) Puncionar acesso venoso periférico." +
                    "\n4) Administrar analgésico e antitérmico endovenosos conforme prescrição médica." +
                    "\n5) Monitorar nível de consciência da paciente a cada 2 horas." +
                    "\n6) Postergar administração de antimicrobianos até definição do quadro infecioso da paciente pela equipe médica.";
                break;
        }
        return txt_feedback;
    }
}
