using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCustomize : MonoBehaviour
{
    public EsteticaNurse nurseDataPack;
    public NurseManage nurseManage;
    public GameObject enfermeiro;
    public GameObject masculino;
    public GameObject feminino;

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
