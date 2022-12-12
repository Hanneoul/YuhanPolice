using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager _Maininstance;
    public int StageNum;
    private void Awake()
    {
        if (_Maininstance == null)
        {
            _Maininstance = this;
        }
        else if (_Maininstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
}
