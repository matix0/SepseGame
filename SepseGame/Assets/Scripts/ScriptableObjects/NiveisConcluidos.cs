using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NiveisConcluidos", menuName = "NiveisConcluidos")]

public class NiveisConcluidos : ScriptableObject
{
    public List<bool> casos;

    public bool emailEnviado = false;
}
