using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelecionarNiveisManager : MonoBehaviour
{
    public Camera camera;
    public GameObject StarCount1, StarCount2;

    int starCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < 13; i++)
        {
            starCount += PlayerPrefs.GetInt("caso" + i.ToString());
        }
        StarCount1.GetComponent<TextMeshProUGUI>().text = "/39";
        StarCount2.GetComponent<TextMeshProUGUI>().text = "/39";
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
