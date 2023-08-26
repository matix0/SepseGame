using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PranchetaBtn : MonoBehaviour
{
    public void PlaySlideIn()
    {
        GetComponent<Animator>().Play("pranch_slide_in");
    }

    public void PlaySlideOut()
    {
        GetComponent<Animator>().Play("pranch_slide_out");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
