using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escolhas : MonoBehaviour
{
    public GameObject content;

    Animation anim;
    public bool isMIn = false;
    public bool isEFIn = false;
    public bool isEIn = false;
    public bool isPIn = false;

    public void monitorizar()
    {
        if (isPlaying(GameObject.Find("PanelMonitorizar").GetComponent<Animator>(), "In") || isPlaying(GameObject.Find("PanelMonitorizar").GetComponent<Animator>(), "Out"))
        {
            return;
        }
        else if (!isMIn)
        {
            GameObject.Find("PanelMonitorizar").GetComponent<Animator>().Play("In");
            isMIn = true;
            disable(0);
            return;
        }
        else
        {
            GameObject.Find("PanelMonitorizar").GetComponent<Animator>().Play("Out");
            isMIn = false;
            return;
        }
    }

    public void examesFiscos()
    {
        if (isPlaying(GameObject.Find("PanelExamesFisicos").GetComponent<Animator>(), "InExamesFisicos") || isPlaying(GameObject.Find("PanelMonitorizar").GetComponent<Animator>(), "OutExamesFisicos"))
        {
            return;
        }
        else if (!isEFIn)
        {
            GameObject.Find("PanelExamesFisicos").GetComponent<Animator>().Play("InExamesFisicos");
            isEFIn = true;
            disable(1);
            return;
        }
        else
        {
            GameObject.Find("PanelExamesFisicos").GetComponent<Animator>().Play("OutExamesFisicos");
            isEFIn = false;
            return;
        }
    }

    public void exames()
    {
        if (isPlaying(GameObject.Find("PanelExames").GetComponent<Animator>(), "InExames") || isPlaying(GameObject.Find("PanelExames").GetComponent<Animator>(), "OutExames"))
        {
            return;
        }
        else if (!isEIn)
        {
            GameObject.Find("PanelExames").GetComponent<Animator>().Play("InExames");
            isEIn = true;
            disable(2);
            return;
        }
        else
        {
            GameObject.Find("PanelExames").GetComponent<Animator>().Play("OutExames");
            isEIn = false;
            return;
        }
    }

    public void prancheta()
    {
        if (isPlaying(content.GetComponent<Animator>(), "content_slide_in") || isPlaying(content.GetComponent<Animator>(), "content_slide_in"))
        {
            return;
        }
        else if (!isPIn)
        {
            content.GetComponent<Animator>().Play("content_slide_in");
            isPIn = true;
            disable(3);
            return;
        }
        else
        {
            content.GetComponent<Animator>().Play("content_slide_out");
            isPIn = false;
            return;
        }
    }

    bool isPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void disable(int exception)
    {
        if (isMIn && exception != 0)
        {
            GameObject.Find("PanelMonitorizar").GetComponent<Animator>().Play("Out");
            isMIn = false;
        }
        if(isEFIn && exception != 1)
        {
            GameObject.Find("PanelExamesFisicos").GetComponent<Animator>().Play("OutExamesFisicos");
            isEFIn = false;
        }
        if (isEIn && exception != 2)
        {
            GameObject.Find("PanelExames").GetComponent<Animator>().Play("OutExames");
            isEIn = false;
        }
        if (isPIn && exception != 3)
        {
            content.GetComponent<Animator>().Play("content_slide_out");
            isPIn = false;
        }
    }
}
