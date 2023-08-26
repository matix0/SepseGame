using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pacote : MonoBehaviour
{
    public List<string> condutas;
    public List<int> selecaoCondutas;

    public GameObject CondutasObject;
    public GameObject ResultadoObject;

    public Estetica pack;

    public Button avancarButton;

    public List<Text> opcoes;

    public List<Toggle> toggles;

    public List<PacotaoGridItem> toggleScripts;

    List<int> numerosSorteados = new List<int>();

    int control = 0;

    void Start()
    {
        updateOptions();
    }

    void updateOptions()
    {
        int i;
        int rand;
        for (i=0; i < opcoes.Count; i++)
        {
            do
            {
              rand = Random.Range(0, 6);
            } while(numerosSorteados.Contains(rand));

            numerosSorteados.Add(rand);
            opcoes[rand].text = condutas[i];
            toggleScripts[rand].condutaIndex = i;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            numerosSorteados.Clear();
            updateOptions();
        }
    }

    public void optionClicked(int idx)
    {
        int retorno = toggleScripts[idx].updt(control + 1);
        switch (retorno)
        {
            case 1:
                selecaoCondutas.Add(toggleScripts[idx].condutaIndex);
                control++;
                break;
            case 2:
                selecaoCondutas.Remove(toggleScripts[idx].condutaIndex);
                control--;
                break;
        }

        if (control == 6)
        {
            avancarButton.interactable = true;
        }
        else
        {
            avancarButton.interactable = false;
        }
    }

    public void resetSelection()
    {
        control = 0;
        selecaoCondutas.Clear();
        int i;
        for(i=0; i < toggleScripts.Count; i++)
        {
            toggleScripts[i].rst();
        }
    }

    public void Avancar()
    {
        ResultadoObject.SetActive(true);
        CondutasObject.SetActive(false);
    }
}
