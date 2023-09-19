using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [HideInInspector]
    public string name;
    public int level;
    public float exp;
    public float nextExp;
    public Image uiBar;
    public int glod;

    public void SetName(string s)
    {
        name = s;
    }

    public void AddLevel(int n)
    {
        level += n;
    }

}
