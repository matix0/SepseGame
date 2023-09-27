using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class PranchetaManager : MonoBehaviour
{
    public Caso Caso;
    public List<string> SinaisVitais;
    public Sprite Imagem;
    public string descricaoImagem;
    public List<string> Lab;
    public Text[] texts;
    public Toggle[] Toggles;
    public GameObject NotificacaoButton;
    public GameObject notificationText;
    public Estetica pack;
    public GameObject pranchetaDiag;
    public GameObject diagText;
    public GameObject ExameImagem;
    public GameObject xray;
    public GameObject pranchImg;
    public GameObject pranchTxt;
    public GameObject PopUpVerificamedico;
    public GameObject bsepse1, bsepse2;
    public GameObject exameDesc;
    public GameObject sangue;
    public GameObject s1, s2, s3, s4;
    int chamadaMedico;

    public List<int> selecionados;
    List<int> aferidos = new List<int>();
    string setText;

    public GameObject HospitalObject;
    public GameObject CondutasObject;

    public bool chamouEquipe;
    public bool abriuProtocolo;

    public int apertouBotao; //0 = primeiro botao e 1 = segundo botao

    public void updateFC()
    {
        if (!texts[0].text.Contains(SinaisVitais[0]))
        {
            texts[0].text = texts[0].text + " " + SinaisVitais[0];
        }
        setText = SinaisVitais[0];
        if (!aferidos.Contains(0))
        {
            aferidos.Add(0);
        }
        EnterNotificacao();
    }

    public void updatePAS()
    {
        if (!texts[1].text.Contains(SinaisVitais[1]))
        {
            texts[1].text = texts[1].text + " " + SinaisVitais[1];
        }
        setText = SinaisVitais[1];
        if (!aferidos.Contains(1))
        {
            aferidos.Add(1);
        }
        EnterNotificacao();
    }

    public void updateSO()
    {
        if (!texts[2].text.Contains(SinaisVitais[2]))
        {
            texts[2].text = texts[2].text + " " + SinaisVitais[2];
        }
        setText = SinaisVitais[2];
        if (!aferidos.Contains(2))
        {
            aferidos.Add(2);
        }
        EnterNotificacao();
    }

    public void updateFR()
    {
        if (!texts[3].text.Contains(SinaisVitais[3]))
        {
            texts[3].text = texts[3].text + " " + SinaisVitais[3];
        }
        setText = SinaisVitais[3];
        if (!aferidos.Contains(3))
        {
            aferidos.Add(3);
        }
        EnterNotificacao();
    }

    public void updateTA()
    {
        if (!texts[4].text.Contains(SinaisVitais[4]))
        {
            texts[4].text = texts[4].text + " " + SinaisVitais[4];
        }
        setText = SinaisVitais[4];
        if (!aferidos.Contains(4))
        {
            aferidos.Add(4);
        }
        EnterNotificacao();
    }

    public void updateNeuro()
    {
        if (!texts[5].text.Contains(SinaisVitais[5]))
        {
            texts[5].text = texts[5].text + " " + SinaisVitais[5];
        }
        setText = SinaisVitais[5];
        if (!aferidos.Contains(5))
        {
            aferidos.Add(5);
        }
        EnterNotificacao();
    }

    public void updateResp()
    {
        if (!texts[6].text.Contains(SinaisVitais[6]))
        {
            texts[6].text = texts[6].text + " " + SinaisVitais[6];
        }
        setText = SinaisVitais[6];
        if (!aferidos.Contains(6))
        {
            aferidos.Add(6);
        }
        EnterNotificacao();
    }

    public void updateCardio()
    {
        if (!texts[7].text.Contains(SinaisVitais[7]))
        {
            texts[7].text = texts[7].text + " " + SinaisVitais[7];
        }
        setText = SinaisVitais[7];
        if (!aferidos.Contains(7))
        {
            aferidos.Add(7);
        }
        EnterNotificacao();
    }

    public void updateGastro()
    {
        if (!texts[8].text.Contains(SinaisVitais[8]))
        {
            texts[8].text = texts[8].text + " " + SinaisVitais[8];
        }
        setText = SinaisVitais[8];
        if (!aferidos.Contains(8))
        {
            aferidos.Add(8);
        }
        EnterNotificacao();
    }

    public void updateRenal()
    {
        if (!texts[9].text.Contains(SinaisVitais[9]))
        {
            texts[9].text = texts[9].text + " " + SinaisVitais[9];
        }
        setText = SinaisVitais[9];
        if (!aferidos.Contains(9))
        {
            aferidos.Add(9);
        }
        EnterNotificacao();
    }

    public void updateLab()
    {
        if (!texts[10].text.Contains(Lab[0]))
        {
            texts[10].text = texts[10].text + " " + Lab[0];
        }
        if (!texts[11].text.Contains(Lab[1]))
        {
            texts[11].text = texts[11].text + " " + Lab[1];
        }
        if (!texts[12].text.Contains(Lab[2]))
        {
            texts[12].text = texts[12].text + " " + Lab[2];
        }
        if (!texts[13].text.Contains(Lab[3]))
        {
            texts[13].text = texts[13].text + " " + Lab[3];
        }

        if(Lab[0] != "não tem")
        {
            if (!aferidos.Contains(10))
            {
                aferidos.Add(10);
            }
            if (!aferidos.Contains(11))
            {
                aferidos.Add(11);
            }
            if (!aferidos.Contains(12))
            {
                aferidos.Add(12);
            }
            if (!aferidos.Contains(13))
            {
                aferidos.Add(13);
            }
        }
        
        if (Lab[0] == "não tem")
        {
            setText = Lab[0];
            EnterNotificacao();
        }
        else
        {
            s1.GetComponent<TextMeshProUGUI>().text = Lab[0];
            s2.GetComponent<TextMeshProUGUI>().text = Lab[1];
            s3.GetComponent<TextMeshProUGUI>().text = Lab[2];
            s4.GetComponent<TextMeshProUGUI>().text = Lab[3];
            sangue.SetActive(true);
        }
    }

    public void UpdateSelected()
    {
        int i;
        for (i = 0; i < Toggles.Length; i++)
        {
            if (Toggles[i].isOn)
            {
                if (!selecionados.Contains(i))
                {
                    selecionados.Add(i);
                }
            }
            else
            {
                selecionados.Remove(i);
            }
        }
        if (selecionados.Count > 0)
        {
            bsepse1.GetComponent<Button>().interactable = true;
            bsepse2.GetComponent<Button>().interactable = true;
        }
        else
        {
            bsepse1.GetComponent<Button>().interactable = false;
            bsepse2.GetComponent<Button>().interactable = false;
        }
    }

    public void updatePrancheta()
    {
        int i;
        for (i = 0; i < Toggles.Length; i++)
        {
            if (aferidos.Contains(i))
            {
                Toggles[i].interactable = true;
            }
        }
    }
    public void EnterNotificacao()
    {
        notificationText.GetComponent<TextMeshProUGUI>().text = setText;
        //texts[11].text = texts[setText].text;
        NotificacaoButton.SetActive(true);

    }
    public void OutNotificacao()
    {
        NotificacaoButton.SetActive(false);
    }

    public void showXray()
    {
        if (Imagem != null)
        {
            xray.GetComponent<Image>().sprite = Imagem;
            ExameImagem.SetActive(true);
            pranchImg.GetComponent<Image>().sprite = Imagem;
            pranchTxt.GetComponent<TextMeshProUGUI>().text = descricaoImagem;
            exameDesc.GetComponent<TextMeshProUGUI>().text = descricaoImagem;
        }
        else
        {
            setText = "não possui";
            EnterNotificacao();
        }
    }

    public void darDiagnostico()
    {
        pranchetaDiag.SetActive(true);
        if(Caso.buttonCorreto == 0)
        {
            diagText.GetComponent<Text>().text = "SEPSE PROVÁVEL";
        }
        else if(Caso.buttonCorreto == 1)
        {
            diagText.GetComponent<Text>().text = "SEPSE POSSÍVEL";
        }
        else if(Caso.buttonCorreto == 2)
        {
            diagText.GetComponent<Text>().text = "Suspeita de DENGUE";
        }
        else if(Caso.buttonCorreto == 3)
        {
            diagText.GetComponent<Text>().text = "Síndrome GRIPAL";
        }
        else if(Caso.buttonCorreto == 4)
        {
            diagText.GetComponent<Text>().text = "Suspeita de EMBOLIA PULMONAR";
        }
    }

    public void hideDiagnostico()
    {
        pranchetaDiag.SetActive(false);
        Caso.pontuacao = 0;
    }

    public void opcaoUm()
    {
        apertouBotao = 0;
        CondutasObject.SetActive(true);
        HospitalObject.SetActive(false);
    }

    public void opcaoDois()
    {
        apertouBotao = 1;
        CondutasObject.SetActive(true);
        HospitalObject.SetActive(false);
    }

    //public void VerificarChamadaMedico(int idx)
    //{
    //    if (idx == 0)
    //    {
    //        if (Caso.buttonCorreto == 0)
    //        {
    //            Caso.abriuProtocolo = true;
    //            Caso.pontuacao += 15;
    //        }
    //        else if (Caso.buttonCorreto >0)
    //        {
    //            Caso.pontuacao -= 10;
    //        }
                
    //    }
    //    else if(idx == 1)
    //    {
    //        if (Caso.buttonCorreto == 0)
    //        {
    //            Caso.abriuProtocolo = false;
    //            Caso.pontuacao -= 10;
    //        }
    //        else if(Caso.buttonCorreto > 0)
    //        {
    //            Caso.pontuacao += 10;
    //        }
            
    //    }
    //    PopUpVerificamedico.SetActive(true);
    //}

    public void chamarEquipe()
    {
        chamouEquipe = true;
        PopUpVerificamedico.SetActive(false);
        darDiagnostico();
    }

    public void naoChamarEquipe()
    {
        chamouEquipe = false;
        PopUpVerificamedico.SetActive(false);
        darDiagnostico();
    }
    public void abrirProtocolo()
    {
        abriuProtocolo = true;
        PopUpVerificamedico.SetActive(true);
    }

    public void naoAbrirProtocolo()
    {
        abriuProtocolo = false;
        PopUpVerificamedico.SetActive(true);
    }
}
