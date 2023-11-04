using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Caso1 : MonoBehaviour
{
    public int Caso;
    public bool sexo = false;

    public GameObject hospitalFeedback;
    public GameObject CasoAtualDisplay;
    public GameObject CasoClinicoAvatarBG, Paciente;
    public GameObject CasoClinicoObject;
    public GameObject DialogoObject;
    public GameObject HospitalObject;
    public GameObject CondutasObject;
    public GameObject ResultadoObject;
    public GameObject FeedbackObject;
    public GameObject helpMenu;
    public DialogManager dialogManager;
    public FeedbackManager feedbackManager;

    public NiveisConcluidos niveisConcluidos;

    bool is_dialog_done = false;

    void Start() //deixa apenas o Caso Clinico visivel de inicio
    {
        CasoAtualDisplay.GetComponent<TextMeshProUGUI>().text = "Caso " + Caso.ToString() + "/13";
        CasoClinicoObject.SetActive(true);
        DialogoObject.SetActive(false);
        HospitalObject.SetActive(false);
        hospitalFeedback.SetActive(false);
        CondutasObject.SetActive(false);
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(false);
        helpMenu.SetActive(false);
    }

    public void FecharCasoClinico() //fecha o Caso Clínico (avança para o Diálogo caso o diálogo ainda não tenha ocorrido)
    {
        Paciente.transform.localPosition = new Vector3(-0.45f, -1.18f, 1);
        Paciente.transform.localScale = new Vector3(1, 1, 1);
        CasoClinicoAvatarBG.SetActive(false);
        CasoClinicoObject.SetActive(false);
        if (!is_dialog_done)
        {
            DialogoObject.SetActive(true);
            dialogManager.loadTexts(0);
        }

    }

    public void AbrirCasoClinico() //acessa o Caso Clínico a partir do Hospital
    {
        Paciente.transform.localPosition = new Vector3(1.47f, -2.421f, 1);
        Paciente.transform.localScale = new Vector3(2, 2, 2);
        CasoClinicoAvatarBG.SetActive(true);
        CasoClinicoObject.SetActive(true);
    }

    public void nextDialog() //chamada ao apertar o botão de Continuar o Diálogo
    {
        if (dialogManager.currentDialog == 0)
        {
            dialogManager.loadTexts(1);
        }
        else
        {
            dialogManager.loadTexts(2);
            if (!is_dialog_done)
            {
                is_dialog_done = true;
            }
            else
            {
                DialogoObject.SetActive(false);
                HospitalObject.SetActive(true);
            }
        }
    }

    public void IrParaFeedback() //avança para o feedback ao pressionar o botão de Continuar nas Condutas
    {
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(true);
        feedbackManager.gerarFeedback();
    }

    void saveStars() //salva o numero de estrelas obtidas no caso nas PlayerPrefs
    {
        if (feedbackManager.estrelas > PlayerPrefs.GetInt("caso" + Caso.ToString()))
        {
            PlayerPrefs.SetInt("caso" + Caso.ToString(), feedbackManager.estrelas);
        }
        niveisConcluidos.casos[Caso - 1] = true;
    }

    public void retryCase() //recarrega a cena ao pressionar o botão Tentar Novamente no Feedback
    {
        saveStars();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextCase() //avança para o Seletor de Níveis ao apertar o botão no Feedback
    {
        saveStars();
        SceneManager.LoadScene("SelecionarNiveis");
    }

    public void openHelp() //abre a tela de Ajuda ao pressionar no ícone no canto superior direito
    {
        helpMenu.SetActive(true);
    }

    public void closeHelp() //fecha a tela de Ajuda
    {
        helpMenu.SetActive(false);
    }

    public void goToHospitalFeedback()
    {
        hospitalFeedback.SetActive(false);
    }

    public void condutasActivate()
    {
        hospitalFeedback.SetActive(false);
        CondutasObject.SetActive(true);
    }
}

