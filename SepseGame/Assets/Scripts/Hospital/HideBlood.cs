using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBlood : MonoBehaviour
{
    public GameObject ExameImagem, sangue;

    private void OnMouseDown()
    {
        ExameImagem.SetActive(false);
        sangue.SetActive(false);
    }
}
