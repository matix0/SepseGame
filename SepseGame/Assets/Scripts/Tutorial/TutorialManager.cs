using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public Sprite[] tutorialSprites = new Sprite[10];
    public Image atualSprite;
    public TextMeshProUGUI tutorialText, pageCountText;
    public GameObject btn_proximo,tutorial;
    int currentPage = 1;
    TextMeshProUGUI btn_texto;
    [System.Obsolete]
    private void Start()
    {
        atualSprite.sprite = tutorialSprites[0];
        pageCountText.text = $"{tutorialText.pageToDisplay} / 12";
        //Debug.Log($"Paginas: {tutorialText.textInfo.pageCount}, atual: {currentPage}" );
        btn_texto = btn_proximo.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        //Debug.Log(btn_texto.text);
    }

    public void NextPage()
    {
        int totalpages = tutorialText.textInfo.pageCount;
        
        if (currentPage < totalpages)
        {
            currentPage++;
            tutorialText.pageToDisplay++;
            pageCountText.text = $"{tutorialText.pageToDisplay} / {tutorialText.textInfo.pageCount}";
            atualSprite.sprite = tutorialSprites[currentPage - 1];
        }
        if (currentPage == 12 && btn_texto.text == "Concluir")
        {
            ExitTutorial();
        }
        if (currentPage == 12)
        {
            btn_texto.text = "Concluir";
            
        }

        //Debug.Log($"Paginas: {tutorialText.textInfo.pageCount}, atual: {currentPage}");
    }
    public void PreviousPage()
    {
        int totalpages = tutorialText.textInfo.pageCount;
        if (currentPage > 1)
        {
            currentPage--;
            tutorialText.pageToDisplay--;
            pageCountText.text = $"{tutorialText.pageToDisplay} / {tutorialText.textInfo.pageCount}";
            atualSprite.sprite = tutorialSprites[currentPage - 1];
        }

        if (currentPage == 11)
        {
            btn_texto.text = "Continuar";
        }

        //Debug.Log($"Paginas: {tutorialText.textInfo.pageCount}, atual: {currentPage}");
    }

    public void ExitTutorial()
    {
        GameObject.Find("Tutorial").SetActive(false);
    }

    public void AbrirTutorial() {
        tutorial.SetActive(true);
    }
}
