using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideXray : MonoBehaviour
{
    public GameObject ExameImagem, xray;

    public void hideXray()
    {
        // ExameImagem.SetActive(false);
        xray.SetActive(false);
    }
}
