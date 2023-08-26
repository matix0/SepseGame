using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NurseOutfitChange : MonoBehaviour
{
    public NurseManage nm;
    public EsteticaNurse en;
    public GameObject E1;
    public GameObject E2;
    public Sprite btn1Change;
    public Sprite btn2Change;
    bool seeBtn;
    private void Start()
    {
        
    }

    public void Randomize()
    {
        nm.Generate();
        en.gender = nm.gender;
    }

    private int currentOptionSkin = 0;
    private int currentOptionHair = 0;
    private int currentOptionBigas = 0;
    private int currentOptionOclin = 0;
    private int currentOptionEstetoscopio = 0;
    private int currentOptionMascara = 0;
    private int currentOptionRoupa = 0;

    public void SexoM()
    {
        nm.GenerateMale();
        en.gender = 0;
        nm.gender = 0;
    }

    public void SexoF()
    {
        nm.GenerateFemale();
        en.gender = 1;
        nm.gender = 1;
    }

    public void Nurse()
    {
        seeBtn = false;
        GameObject ProfissaoF = GameObject.Find("ProfissaoF");
        GameObject Profissao = GameObject.Find("Profissao");
        if(!seeBtn){
            E1.GetComponent<Image>().sprite = btn2Change;
            E2.GetComponent<Image>().sprite = btn1Change;
        }
       

        if (en.gender == 0)
        {
            nm.role = 0;
            en.role = 0;
            Profissao.GetComponent<SpriteRenderer>().sprite = nm.profissaoArray[0];
        }
        else
        {
            nm.role = 0;
            en.role = 0;
            ProfissaoF.GetComponent<SpriteRenderer>().sprite = nm.profissaoArrayF[0];
        }
    }

    public void Doctor()
    {
        seeBtn = true;
        GameObject ProfissaoF = GameObject.Find("ProfissaoF");
        GameObject Profissao = GameObject.Find("Profissao");

        if (seeBtn)
        {
            E1.GetComponent<Image>().sprite = btn1Change;
            E2.GetComponent<Image>().sprite = btn2Change;
        }

        if (en.gender == 0)
        {
            Profissao.GetComponent<SpriteRenderer>().sprite = nm.profissaoArray[1];
            nm.role = 1;
            en.role = 1;
        }
        else
        {
            nm.role = 1;
            en.role = 1;
            ProfissaoF.GetComponent<SpriteRenderer>().sprite = nm.profissaoArrayF[1];
        }

    }
    public void NextRoupa()
    {
        GameObject ProfissaoF = GameObject.Find("ProfissaoF");
        GameObject Profissao = GameObject.Find("Profissao");
        if (en.gender == 0)
        {
            currentOptionRoupa++;
            if (currentOptionRoupa >= nm.profissaoArray.Length)
            {
                currentOptionRoupa = 0;
            }
            Profissao.GetComponent<SpriteRenderer>().sprite = nm.profissaoArray[currentOptionRoupa];
            nm.role = currentOptionRoupa;
            en.role = currentOptionRoupa;
        }
        else
        {
            currentOptionRoupa++;
            if (currentOptionRoupa >= nm.profissaoArrayF.Length)
            {
                currentOptionRoupa = 0;
            }
            ProfissaoF.GetComponent<SpriteRenderer>().sprite = nm.profissaoArrayF[currentOptionRoupa];
            nm.role = currentOptionRoupa;
            en.role = currentOptionRoupa;
        }
    }

    public void PreviousRoupa()
    {
        GameObject ProfissaoF = GameObject.Find("ProfissaoF");
        GameObject Profissao = GameObject.Find("Profissao");
        if (en.gender == 0)
        {
            Debug.Log(currentOptionRoupa);
            currentOptionRoupa--;
            if (currentOptionRoupa < 0)
            {
                currentOptionRoupa = nm.peleArray.Length - 1;

            }
            Profissao.GetComponent<SpriteRenderer>().sprite = nm.profissaoArray[currentOptionRoupa];
            nm.role = currentOptionRoupa;
            en.role = currentOptionRoupa;
        }
        else
        {
            Debug.Log(currentOptionRoupa);
            currentOptionRoupa--;
            if (currentOptionRoupa < 0)
            {
                currentOptionRoupa = nm.peleArrayF.Length - 1;
            }
            ProfissaoF.GetComponent<SpriteRenderer>().sprite = nm.profissaoArrayF[currentOptionRoupa];
            nm.role = currentOptionRoupa;
            en.role = currentOptionRoupa;
        }
    }
    /**/
    public void NextSkin()
    {
        GameObject Pele = GameObject.Find("Pele");
        GameObject PeleF = GameObject.Find("PeleF");
        if (en.gender == 0)
        {
            //Debug.Log(en.gender);
            currentOptionSkin++;
            if (currentOptionSkin >= nm.peleArray.Length)
            {
                currentOptionSkin = 0;
            }
            Pele.GetComponent<SpriteRenderer>().sprite = nm.peleArray[currentOptionSkin];
            nm.corDaPele = currentOptionSkin;
            en.corDaPele = currentOptionSkin;
        }
        else
        {
            currentOptionSkin++;
            if (currentOptionSkin >= nm.peleArrayF.Length)
            {
                currentOptionSkin = 0;
            }
            PeleF.GetComponent<SpriteRenderer>().sprite = nm.peleArrayF[currentOptionSkin];
            nm.corDaPele = currentOptionSkin;
            en.corDaPele = currentOptionSkin;
        }
    }

    public void PreviousSkin()
    {
        GameObject Pele = GameObject.Find("Pele");
        GameObject PeleF = GameObject.Find("PeleF");
        if (en.gender == 0)
        {
            currentOptionSkin--;
            if (currentOptionSkin < 0)
            {
                currentOptionSkin = nm.peleArray.Length - 1;
                
            }
            Pele.GetComponent<SpriteRenderer>().sprite = nm.peleArray[currentOptionSkin];
            nm.corDaPele = currentOptionSkin;
            en.corDaPele = currentOptionSkin;
        }
        else
        {
            currentOptionSkin--;
            if (currentOptionSkin < 0)
            {
                currentOptionSkin = nm.peleArrayF.Length - 1;
            }
            PeleF.GetComponent<SpriteRenderer>().sprite = nm.peleArrayF[currentOptionSkin];
            nm.corDaPele = currentOptionSkin;
            en.corDaPele = currentOptionSkin;
        }
    }
    public void NextHair()
    {
        GameObject Cabelo = GameObject.Find("Cabelin");
        GameObject CabeloF = GameObject.Find("CabelinF");
        if (en.gender == 0)
        {
            currentOptionHair++;
            if (currentOptionHair >= nm.cabeloArray.Length)
            {
                currentOptionHair = 0;
            }
            Cabelo.GetComponent<SpriteRenderer>().sprite = nm.cabeloArray[currentOptionHair];
            nm.hasCabas = currentOptionHair;
            nm.cabelin = currentOptionHair;
            en.cabelin = currentOptionHair;
        }
        else
        {
            currentOptionHair++;
            if (currentOptionHair >= nm.cabeloArrayF.Length)
            {
                currentOptionHair = 0;
            }
            CabeloF.GetComponent<SpriteRenderer>().sprite = nm.cabeloArrayF[currentOptionHair];
            nm.hasCabas = currentOptionHair;
            nm.cabelin = currentOptionHair;
            en.cabelin = currentOptionHair;
        }
    }

    public void PreviousHair()
    {

        GameObject Cabelo = GameObject.Find("Cabelin");
        GameObject CabeloF = GameObject.Find("CabelinF");
        if (en.gender == 0)
        {
            currentOptionHair--;
            if (currentOptionHair < 0)
            {
                currentOptionHair = nm.cabeloArray.Length - 1;
            }
            Cabelo.GetComponent<SpriteRenderer>().sprite = nm.cabeloArray[currentOptionHair];
            nm.hasCabas = currentOptionHair;
            nm.cabelin = currentOptionHair;
            en.cabelin = currentOptionHair;
        }
        else
        {
            currentOptionHair--;
            if (currentOptionHair < 0)
            {
                currentOptionHair = nm.cabeloArrayF.Length - 1;
            }
            CabeloF.GetComponent<SpriteRenderer>().sprite = nm.cabeloArrayF[currentOptionHair];
            nm.hasCabas = currentOptionHair;
            nm.cabelin = currentOptionHair;
            en.cabelin = currentOptionHair;
        }
    }

    public void NextOclin()
    {
        GameObject Oclin = GameObject.Find("AcessorioRosto");
        GameObject OclinF = GameObject.Find("AcessorioRostoF");
        if (en.gender == 0)
        {
            currentOptionOclin++;
            if (currentOptionOclin >= nm.oclinArray.Length)
            {
                currentOptionOclin = 0;
            }
            Oclin.GetComponent<SpriteRenderer>().sprite = nm.oclinArray[currentOptionOclin];
            nm.hasOclin = currentOptionOclin;
            en.hasOclin = currentOptionOclin;
        }
        else
        {
            currentOptionOclin++;
            if (currentOptionOclin >= nm.oclinArray.Length)
            {
                currentOptionOclin = 0;
            }
            OclinF.GetComponent<SpriteRenderer>().sprite = nm.oclinArray[currentOptionOclin];
            nm.hasOclin = currentOptionOclin;
            en.hasOclin = currentOptionOclin;
        }
    }

    public void PreviousOclin()
    {
        GameObject Oclin = GameObject.Find("AcessorioRosto");
        GameObject OclinF = GameObject.Find("AcessorioRostoF");

        if (en.gender == 0)
        {
            currentOptionOclin--;
            if (currentOptionOclin < 0)
            {
                currentOptionOclin = 1;
            }
            Oclin.GetComponent<SpriteRenderer>().sprite = nm.oclinArray[currentOptionOclin];
            nm.hasOclin = currentOptionOclin;
            en.hasOclin = currentOptionOclin;
        }
        else
        {
            currentOptionOclin--;
            if (currentOptionOclin < 0)
            {
                currentOptionOclin = 1;
            }
            OclinF.GetComponent<SpriteRenderer>().sprite = nm.oclinArray[currentOptionOclin];
            nm.hasOclin = currentOptionOclin;
            en.hasOclin = currentOptionOclin;
        }
    }

    public void NextBigas()
    {
        GameObject PeloFacial = GameObject.Find("PeloFacial");


        currentOptionBigas++;
        if (currentOptionBigas >= nm.barbaArray.Length)
        {
            currentOptionBigas = 0;
        }
        PeloFacial.GetComponent<SpriteRenderer>().sprite = nm.barbaArray[currentOptionBigas];
        nm.hasBigas = currentOptionBigas;
        nm.bigas = currentOptionBigas;
        en.bigas = currentOptionBigas;
    }

    public void PreviousBigas()
    {
        GameObject PeloFacial = GameObject.Find("PeloFacial");


        currentOptionBigas--;
        if (currentOptionBigas < 0)
        {
            currentOptionBigas = nm.barbaArray.Length - 1;
        }
        PeloFacial.GetComponent<SpriteRenderer>().sprite = nm.barbaArray[currentOptionBigas];
        nm.hasBigas = currentOptionBigas;
        nm.bigas = currentOptionBigas;
        en.bigas = currentOptionBigas;
    }

    public void NextEstetoscopio()
    {
        GameObject Estetoscopio = GameObject.Find("Estetoscopio");
        GameObject EstetoscopioF = GameObject.Find("EstetoscopioF");

        if (en.gender == 0)
        {
            currentOptionEstetoscopio++;
            if (currentOptionEstetoscopio >= nm.estetoscopioArray.Length)
            {
                currentOptionEstetoscopio = 0;
            }
            Estetoscopio.GetComponent<SpriteRenderer>().sprite = nm.estetoscopioArray[currentOptionEstetoscopio];
            nm.estetoscopio = currentOptionEstetoscopio;
            en.estetoscopio = currentOptionEstetoscopio;
        }
        else
        {
            currentOptionEstetoscopio++;
            if (currentOptionEstetoscopio >= nm.estetoscopioArray.Length)
            {
                currentOptionEstetoscopio = 0;
            }
            EstetoscopioF.GetComponent<SpriteRenderer>().sprite = nm.estetoscopioArray[currentOptionEstetoscopio];
            nm.estetoscopio = currentOptionEstetoscopio;
            en.estetoscopio = currentOptionEstetoscopio;
        }
    }

    public void PrevEstetoscopio()
    {
        GameObject Estetoscopio = GameObject.Find("Estetoscopio");
        GameObject EstetoscopioF = GameObject.Find("EstetoscopioF");


        if (en.gender == 0)
        {
            currentOptionEstetoscopio--;
            if (currentOptionEstetoscopio < 0)
            {
                currentOptionEstetoscopio = 1;
            }
            Estetoscopio.GetComponent<SpriteRenderer>().sprite = nm.estetoscopioArray[currentOptionEstetoscopio];
            nm.estetoscopio = currentOptionEstetoscopio;
            en.estetoscopio = currentOptionEstetoscopio;
        }
        else
        {
            currentOptionEstetoscopio--;
            if (currentOptionEstetoscopio < 0)
            {
                currentOptionEstetoscopio = 1;
            }
            EstetoscopioF.GetComponent<SpriteRenderer>().sprite = nm.estetoscopioArray[currentOptionEstetoscopio];
            nm.estetoscopio = currentOptionEstetoscopio;
            en.estetoscopio = currentOptionEstetoscopio;
        }
    }

    public void NextMascara()
    {
        GameObject Mascara = GameObject.Find("Mascara");
        GameObject MascaraF = GameObject.Find("MascaraF");

        if (en.gender == 0)
        {
            currentOptionMascara++;
            if (currentOptionMascara >= nm.oclinArray.Length)
            {
                currentOptionMascara = 0;
            }
            Mascara.GetComponent<SpriteRenderer>().sprite = nm.mascaraArray[currentOptionMascara];
            nm.mascara = currentOptionMascara;
            en.mascara = currentOptionMascara;
        }
        else
        {
            currentOptionMascara++;
            if (currentOptionMascara >= nm.oclinArray.Length)
            {
                currentOptionMascara = 0;
            }
            MascaraF.GetComponent<SpriteRenderer>().sprite = nm.mascaraArray[currentOptionMascara];
            nm.mascara = currentOptionMascara;
            en.mascara = currentOptionMascara;
        }
    }

    public void PrevMascara()
    {
        GameObject Mascara = GameObject.Find("Mascara");
        GameObject MascaraF = GameObject.Find("MascaraF");


        if (en.gender == 0)
        {
            currentOptionMascara--;
            if (currentOptionMascara < 0)
            {
                currentOptionMascara = 1;
            }
            Mascara.GetComponent<SpriteRenderer>().sprite = nm.mascaraArray[currentOptionMascara];
            nm.mascara = currentOptionMascara;
            en.mascara = currentOptionMascara;
        }
        else
        {
            currentOptionMascara--;
            if (currentOptionMascara < 0)
            {
                currentOptionMascara = 1;
            }
            MascaraF.GetComponent<SpriteRenderer>().sprite = nm.mascaraArray[currentOptionMascara];
            nm.mascara = currentOptionMascara;
            en.mascara = currentOptionMascara;
        }
    }

}
