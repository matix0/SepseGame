using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeGeneralManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Nurse").GetComponent<NurseManage>().findSlider();

        GameObject.Find("Nurse").transform.position = new Vector3(0,0,1);
        GameObject.Find("Nurse").transform.localScale = new Vector3(5.912176f, 5.912176f, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
