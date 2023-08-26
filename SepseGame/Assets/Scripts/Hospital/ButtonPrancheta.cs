using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrancheta : MonoBehaviour
{
    public Animator anim;

    private void OnMouseExit()
    {
        anim.Play("slide_out");
    }

    private void OnMouseOver()
    {
        anim.Play("slide_in");
    }
}
