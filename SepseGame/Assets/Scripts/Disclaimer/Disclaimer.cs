using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Login");
    }
}
