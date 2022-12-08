using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct initList {
    public String[] Strings;
}
public class ScriptMnager : MonoBehaviour
{
    public List<initList> openingScript;
    public List<initList> endingScript;
    public List<initList> playerScript;
}
