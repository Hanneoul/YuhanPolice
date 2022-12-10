using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct initList {
    public String[] Strings;
}
public class ScriptMnager : MonoBehaviour
{
    public List<initList> openingScript;
    public List<initList> endingScript;
    public List<initList> playerScript;
    public Sprite[] openingImages;

    public Sprite[] hurdleImages;

    public Sprite[] symbolImages;

    public Sprite[] stageClearImages;

    public Sprite[] EnemyImage;
}
