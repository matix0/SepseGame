using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caso1 : MonoBehaviour
{
    public int Caso;
    public bool sexo = false;

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

    bool is_dialog_done = false;

    void Start() //deixa apenas o Caso Clinico visivel de inicio
    {
        CasoClinicoObject.SetActive(true);
        DialogoObject.SetActive(false);
        HospitalObject.SetActive(false);
        CondutasObject.SetActive(false);
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(false);
        helpMenu.SetActive(false);
    }
    
    public void FecharCasoClinico() //fecha o Caso Clínico e avança para o Diálogo
    {
        Paciente.transform.localPosition = new Vector3(-0.45f,-1.18f, 1);
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
        dialogManager.loadTexts(1);
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

    public void IrParaFeedback() //avança para o feedback ao pressionar o botão de Continuar nas Condutas
    {
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(true);
        feedbackManager.gerarFeedback();
    }

    public void retryCase() //recarrega a cena ao pressionar o botão Tentar Novamente no Feedback
    {
        PlayerPrefs.SetInt("caso" + Caso.ToString(), feedbackManager.estrelas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextCase() //avança para o Seletor de Níveis ao apertar o botão no Feedback
    {
        PlayerPrefs.SetInt("caso" + Caso.ToString(), feedbackManager.estrelas);
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
}
