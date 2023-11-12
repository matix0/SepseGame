using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public GameObject CasoClinicoButton, PranchetaButton;
    public GameObject PauseMenuUI;
    public GameObject Escolhas;
    public GameObject PauseIcon;
    public GameObject Tutorial;
    public Button[] buttonsEscolhas;
    //public AudioSource MusicManager;
    public GameObject slider;
    public AudioSource Musica;
    //public Slider slider;

    void Start()
    {
        Time.timeScale = 1f;
        //float sliderValue = slider.value;
        Musica.volume = 0.5f;
    }

    public void Resume()
    {
        CasoClinicoButton.GetComponent<Button>().interactable = true;
        PranchetaButton.GetComponent<Button>().interactable = true;
        PauseIcon.SetActive(true);
        PauseMenuUI.SetActive(false);
        Escolhas.SetActive(true);
        buttonsEscolhas[0].interactable = !buttonsEscolhas[0].interactable;
        buttonsEscolhas[1].interactable = !buttonsEscolhas[1].interactable;
        buttonsEscolhas[2].interactable = !buttonsEscolhas[2].interactable;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        CasoClinicoButton.GetComponent<Button>().interactable = false;
        PranchetaButton.GetComponent<Button>().interactable = false;
        PauseMenuUI.SetActive(true);
        PauseIcon.SetActive(false);
        Escolhas.SetActive(false);
        buttonsEscolhas[0].interactable = !buttonsEscolhas[0].interactable;
        buttonsEscolhas[1].interactable = !buttonsEscolhas[1].interactable;
        buttonsEscolhas[2].interactable = !buttonsEscolhas[2].interactable;

        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelecionarNiveis");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Volume()
    {
        slider = GameObject.Find("Slider_On");
        Debug.Log("slider "+ slider.GetComponent<Slider>().value);
        Musica.volume = slider.GetComponent<Slider>().value;
        Debug.Log("volume " + Musica.volume);
    }

    public void AbrirTutorial()
    {
        Tutorial.SetActive(true);
    }
}
