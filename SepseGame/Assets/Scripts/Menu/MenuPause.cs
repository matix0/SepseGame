using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject Escolhas;
    public GameObject PauseIcon;
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
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    //public void Update()
    //{
    //    //float sliderValue = slider.value;
    //    //MusicManager.volume = sliderValue;
    //}
    public void Volume()
    {
        slider = GameObject.Find("Slider_On");
        Debug.Log("slider "+ slider.GetComponent<Slider>().value);
        Musica.volume = slider.GetComponent<Slider>().value;
        Debug.Log("volume " + Musica.volume);
    }
}
