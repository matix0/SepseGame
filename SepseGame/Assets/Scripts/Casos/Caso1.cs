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

    void Start()
    {
        CasoClinicoObject.SetActive(true);
        DialogoObject.SetActive(false);
        HospitalObject.SetActive(false);
        CondutasObject.SetActive(false);
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(false);
        helpMenu.SetActive(false);
    }
    
    public void FecharCasoClinico()
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

    public void AbrirCasoClinico()
    {
        Paciente.transform.localPosition = new Vector3(1.47f, -2.421f, 1);
        Paciente.transform.localScale = new Vector3(2, 2, 2);
        CasoClinicoAvatarBG.SetActive(true);
        CasoClinicoObject.SetActive(true);
    }

    public void nextDialog()
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

    public void RetornarParaDialogo()
    {
        DialogoObject.SetActive(true);
        HospitalObject.SetActive(false);
    }

    public void IrParaFeedback()
    {
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(true);
        feedbackManager.gerarFeedback();
    }

    public void retryCase()
    {
        PlayerPrefs.SetInt("caso" + Caso.ToString(), feedbackManager.estrelas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextCase()
    {
        PlayerPrefs.SetInt("caso" + Caso.ToString(), feedbackManager.estrelas);
        SceneManager.LoadScene("SelecionarNiveis");
    }

    public void openHelp()
    {
        helpMenu.SetActive(true);
    }

    public void closeHelp()
    {
        helpMenu.SetActive(false);
    }
}
