using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TabInputField : MonoBehaviour
{
    public TMP_InputField NomeInput; //0
    public TMP_InputField CpfInput; //1

    public int InputSelecionado;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            InputSelecionado++;
            if (InputSelecionado > 1) InputSelecionado = 0;
            SelecionarCampo();

        }

        void SelecionarCampo() {
            switch (InputSelecionado) 
            {
                case 0: NomeInput.Select();
                    break;
                case 1: CpfInput.Select();
                    break;
            }
        }

    }
    public void NomeSelecionado() => InputSelecionado = 0;
    public void CpfSelecionado() => InputSelecionado = 1;
}
