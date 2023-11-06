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
   // public GameObject StarCount;
    int auxCountBasico, auxCountAvancado;
    public string nivel,caso;
    public int qtdEstrelas, numeroNivel;
    public NiveisConcluidos niveisConcluidos;
    public Parabens parabens;
    public GameObject popupParabens;


    // Start is called before the first frame update
    void Start()
    {
        GameObject starCountBasico, starCountAvancado;
        starCountBasico = GameObject.Find("StarCountBasico");
        starCountAvancado = GameObject.Find("StarCountAvancado");
        for (int i = 0; i <= 13; i++)
        {

            if (i<7)
            {
                auxCountBasico += PlayerPrefs.GetInt("caso" + i.ToString());
                //Debug.Log("Caso: " + i);
                
            }
            else
            {
                auxCountAvancado += PlayerPrefs.GetInt("caso" + i.ToString());
                //Debug.Log("Caso: " + i);
            }
            
        }
        starCountBasico.GetComponent<TextMeshProUGUI>().text = auxCountBasico.ToString() + "/18";
        starCountAvancado.GetComponent<TextMeshProUGUI>().text = auxCountAvancado.ToString() + "/21";

        if ((auxCountAvancado + auxCountBasico) == 39)
        {
            abrirParabens(3);
        }
        if (auxCountBasico == 18)
        {
            abrirParabens(1);
        }
        if (auxCountAvancado == 21)
        {
            abrirParabens(2);
        }


        //Debug.Log(auxCountBasico);
        //Debug.Log(auxCountAvancado);

        atualizaEstrelasCasos();
        liberaCasos();
    }
    public void liberaCasos()
    {
        for (int i = 0; i < 13; i++)
        {
            if (niveisConcluidos.casos[i])
            {
                GameObject pai,proxNivel;
                Transform auxLiberado,auxConcluido,auxBloqueado;
                pai = GameObject.Find("Nivel " + (i + 1));

                auxLiberado = pai.transform.Find("NivelLiberado");
                auxLiberado.gameObject.SetActive(false);

                auxConcluido = pai.transform.Find("NivelConcluido");
                auxConcluido.gameObject.SetActive(true);

                proxNivel = GameObject.Find("Nivel " + (i + 2));
                auxBloqueado = proxNivel.transform.Find("NivelBloqueado");
                auxBloqueado.gameObject.SetActive(false);
                auxLiberado = proxNivel.transform.Find("NivelLiberado");
                auxLiberado.gameObject.SetActive(true);

            }
        }
    }

    public void atualizaEstrelasCasos()
    {
        for (int i = 1; i <= 13; i++)
        {
            GameObject caso;
            Transform auxConcluido,auxEstrela;
            int qtdEstrelas = PlayerPrefs.GetInt("caso" + i.ToString());
            //Debug.Log(qtdEstrelas);
            caso = GameObject.Find("Nivel " + i);
            //Debug.Log(caso.name);
            auxConcluido = caso.transform.Find("NivelConcluido");
            //Debug.Log(auxConcluido.name);
            auxEstrela = auxConcluido.Find("Estrelas");
            //Debug.Log(auxEstrela);

            switch (qtdEstrelas)
            {
                case 1:
                    auxEstrela.transform.Find("Estrela_2").gameObject.SetActive(false);
                    auxEstrela.transform.Find("Estrela_3").gameObject.SetActive(false);
                    break;
                case 2:
                    auxEstrela.transform.Find("Estrela_3").gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getNivel()
    {

        nivel = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        nivel = nivel.Replace(" ", "");
        //Debug.Log(nivel);

        string auxNumNivel = nivel.Remove(0, 5);
        numeroNivel = int.Parse(auxNumNivel);

        //nivel = "caso" + nivel;     
    }
    public void getCaso() {
        caso = nivel.Remove(0, 5);
        caso = "caso"+ numeroNivel;
        //Debug.Log(caso);
    }
    public void getEstrelasNivel()
    {
        qtdEstrelas = PlayerPrefs.GetInt("caso" + numeroNivel.ToString());
    }

    public void selecionarNivel()
    {
        getNivel();
        getCaso();
        //Debug.Log(caso);
        SceneManager.LoadScene(caso);
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

    public void abrirParabens(int op)
    {

        TextMeshProUGUI auxPopup = popupParabens.transform.Find("Text_Info").gameObject.GetComponent<TextMeshProUGUI>();


        if ((op==1)&&(parabens.basicoConcluido == false))
        {
            irCasosBasicos();
            auxPopup.text = "Incrível! Você agora está preparado (a) para enfrentar casos clinicos mais complexos. Vamos lá!";
            parabens.basicoConcluido = true;
            popupParabens.SetActive(true);
            
        }
        if ((op == 2) && (parabens.avancadoConcluido == false))
        {
            irCasosBasicos();
            auxPopup.text = "Uau! Você resolveu todos os casos clinicos com sucesso, mas o troféu ainda não é seu. Jogue novamente para ganhar mais estrelas e conquistar esse troféu merecido!";
            parabens.avancadoConcluido = true;
            popupParabens.SetActive(true);
            
        }
        if ((op == 3)&&(parabens.jogoConcluido == false))
        {
            irCasosBasicos();
            auxPopup.text = "Fantástico! Você alcançou a vitória e conquistou o seu merecido troféu. Parabéns, pela sua conquista!";
            parabens.jogoConcluido = true;
            popupParabens.SetActive(true);
            
        }
        
    }

    public void fechaParabens()
    {
        GameObject popupFeedback = GameObject.Find("Popup Parabens");
        popupFeedback.SetActive(false);
    }
}
