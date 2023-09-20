using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerInfoSO playerInfo;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(playerInfo.name == "" || playerInfo.name == null)
        {
            playerInfo.name = "new Player";
            playerInfo.level = 1;
            playerInfo.gold = 5000;
        }
    }

}
