using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerInfoSO playerInfo;

    public EquipItem[] equipItems;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        if (playerInfo.name == "" || playerInfo.name == null)
        {
            playerInfo.name = "new Player";
            playerInfo.level = 1;
            playerInfo.gold = 5000;
        }
        StartCoroutine("Test");

    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        foreach (EquipItem e in equipItems)
        {
            Inventory.instance.AddItem(e);
        }
    }

}
