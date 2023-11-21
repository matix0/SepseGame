using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerObj : MonoBehaviour
{
    public float time_elapsed = 0.0f;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("timer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        time_elapsed += Time.deltaTime;
    }
}
