using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideXray : MonoBehaviour
{
    public GameObject ExameImagem;

    private void OnMouseDown()
    {
        ExameImagem.SetActive(false);
    }
}
