using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class SelecionarNiveisManager : MonoBehaviour
{
    FeedbackCasoModal feedbackCasoModal;
    public Camera camera;
    public GameObject StarCount1, StarCount2;
    public GameObject ModalFeedback;

    int starCount;
    public string nivel,caso;
    public int qtdEstrelas, numeroNivel;

    public TMP_Text titulo_modal,texto_feedback;


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < 13; i++)
        {
            starCount += PlayerPrefs.GetInt("caso" + i.ToString());
        }
        StarCount1.GetComponent<TextMeshProUGUI>().text = starCount.ToString() + "/39";
        StarCount2.GetComponent<TextMeshProUGUI>().text = starCount.ToString() + "/39";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getNivel()
    {

        nivel = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        titulo_modal.text = nivel.ToUpper();
        nivel = nivel.Replace(" ", "");
        Debug.Log(nivel);

        string auxNumNivel = nivel.Remove(0, 5);
        numeroNivel = int.Parse(auxNumNivel);

        //nivel = "caso" + nivel;     
    }
    public void getCaso() {
        caso = nivel.Remove(0, 5);
        caso = "caso"+ numeroNivel;
        Debug.Log(caso);
    }
    public void getEstrelasNivel()
    {
        qtdEstrelas = PlayerPrefs.GetInt("caso" + numeroNivel.ToString());
    }
    public void openModalFeedback() {

        getNivel();
        getCaso();
        getEstrelasNivel();
        Debug.Log("nivel: " + nivel
    + "\nqtdEstrelas: " + qtdEstrelas
    + "\ncaso: " + caso
    + "\nnumeroNivel: " + numeroNivel);

        setModalFeedback();

        ModalFeedback.SetActive(true);
    }

    public void setModalFeedback() {
        string teste = feedbackCasoModal.getFeedback();
        texto_feedback.SetText(teste);
    }
    public void selecionarNivel()
    {
        /*
        SceneManager.LoadScene(caso);
        */

        
    }

    public void irCasosBasicos() {
        camera.transform.position = new Vector3(0,0,-10);
    }

    public void irCasosAvancados()
    {
        camera.transform.position = new Vector3(1325, 0, -10);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


}
