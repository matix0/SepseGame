using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pacote : MonoBehaviour
{
    public Estetica pack;

    public Caso Caso;

    public List<Caso> Casos;

    public List<Text> opcoes;

    public List<Toggle> toggles;

    public List<GameObject> bars;

    List<string> certas = new List<string> {"certo0", "certo1", "certo2", "certo3", "certo4", "certo5"};
    List<string> erradas = new List<string> {"r1", "r2", "r3","r4", "r5", "r6"};
    List<int> numerosSorteados = new List<int>();

    int control = 0;
    int respostaCorreta;
    int currentSelected = -1;
    bool once = false;

    bool updating = false;

    int acertos;

    void Start()
    {
        updateOptions();

        Caso = Casos[pack.currentCase - 1];
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
        }

        int j;
        for (j=0; j < numerosSorteados.Count; j++)
        {
            opcoes[j].text = erradas[numerosSorteados[j]];
        }

        respostaCorreta = Random.Range(0, 6);
        opcoes[respostaCorreta].text = certas[control];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            numerosSorteados.Clear();
            updateOptions();
        }
    }

    public void updateChecked(int excludeIndex)
    {
        if (!updating)
        {
            process(excludeIndex);
        }
        
    }

    void process(int excludeIndex)
    {
        updating = true;
        int a;
        for (a = 0; a < toggles.Count; a++)
        {
            if (a != excludeIndex)
            {
                toggles[a].isOn = false;
            }
        }
        updating = false;
        if (!once)
        {
            currentSelected = excludeIndex;
        }
    }

    public void Avancar()
    {
        if (!once)
        {
            control++;
            bars[respostaCorreta].SetActive(true);
            if (currentSelected != respostaCorreta)
            {
                bars[currentSelected].GetComponent<Image>().color = new Color(0.75f, 0, 0, 0.9f);
                bars[currentSelected].SetActive(true);
            }
            else
            {
                acertos++;
            }
            once = true;
        }
        else
        {
            if(control < 6)
            {
                once = false;
                numerosSorteados = new List<int>();
                bars[respostaCorreta].SetActive(false);
                bars[currentSelected].GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
                bars[currentSelected].SetActive(false);

                int k;
                for (k = 0; k < toggles.Count; k++)
                {
                    toggles[k].isOn = false;
                }
                updateOptions();
            }
            else
            {
                Caso.pontuacao += (acertos * 100);
                SceneManager.LoadScene("Pontuacao");
            } 
        }
    }
}
