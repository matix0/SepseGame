using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EsteticaNurse", menuName = "Paciente/EsteticaNurse")]

public class EsteticaNurse : ScriptableObject
{
    public bool set = false;

    public int gender;

    public int corDaPele;
    public int hasBigas;
    public int hasCabas;
    public int hasOclin;
    public int cabelin;
    public int bigas;
    public int role;
    public int estetoscopio;
    public int mascara;
    public int luva;

    public Vector4 corRoupa;
}
