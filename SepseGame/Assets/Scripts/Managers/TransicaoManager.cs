using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransicaoManager : MonoBehaviour
{
    public Estetica Estetica;
    public GameObject text;

    void Start()
    {
        if (Estetica.currentCase == 12)
        {
            SceneManager.LoadScene("FinalScene");
        }
        Estetica.set = false;
        Estetica.currentCase++;
        text.GetComponent<TextMeshProUGUI>().text = "CASO " + (Estetica.currentCase + 1).ToString();
    }

    public void goNext()
    {
        SceneManager.LoadScene("Dialogo");
    }
}
