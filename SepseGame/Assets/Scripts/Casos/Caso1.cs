using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso1 : MonoBehaviour
{
    public GameObject DialogoObject;
    public GameObject HospitalObject;
    public GameObject CondutasObject;
    public GameObject ResultadoObject;
    public GameObject FeedbackObject;
    public FeedbackManager feedbackManager;

    // Start is called before the first frame update
    void Start()
    {
        DialogoObject.SetActive(true);
        HospitalObject.SetActive(false);
        CondutasObject.SetActive(false);
        ResultadoObject.SetActive(false);
        FeedbackObject.SetActive(false);
    }

    public void AvancarDoDialogo()
    {
        DialogoObject.SetActive(false);
        HospitalObject.SetActive(true);
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
}
