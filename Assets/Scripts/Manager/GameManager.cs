using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uIManager;

    private void Awake()
    {
        instance = this;
        uIManager = GetComponentInChildren<UIManager>();
    }

    private void Start()
    {
        uIManager.SetName("new User");
        uIManager.SetLevel(1);
        uIManager.AddGold(5000);
        StartCoroutine("UITest");
    }

    IEnumerator UITest()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            uIManager.AddExp(10f);
            uIManager.AddGold(1000);
        }
    }
}
