using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private PlayerInfoSO playerInfo;

    private void Awake()
    {
        playerInfo = GameManager.instance.playerInfo;
    }

    [SerializeField] private ExpSO expData;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider expSlider;

    private void Start()
    {
        UIUpdateName();
        UIUpdateLevel();
        UIUpdategold();
        UIUpdateExp();
    }

    public void SetLevel(int level)
    {
        playerInfo.level = level;
        playerInfo.nextExp = expData.nextExp[level];
        UIUpdateLevel();
        AddExp(0f);
    }

    public void AddExp(float exp)
    {
        playerInfo.exp += exp;
        if(playerInfo.nextExp <= playerInfo.exp)
        {
            playerInfo.exp -= playerInfo.nextExp;
            SetLevel(++playerInfo.level);
        }
        UIUpdateExp();
    }

    public void AddGold(int gold)
    {
        playerInfo.gold += gold;
        UIUpdategold();
    }

    private void UIUpdateName()
    {
        nameText.text = playerInfo.name;
    }

    private void UIUpdateLevel()
    {
        levelText.text = string.Format($"Level {playerInfo.level}"); 
    }

    private void UIUpdategold()
    {
        goldText.text = string.Format($"{playerInfo.gold}");
    }

    private void UIUpdateExp()
    {
        expSlider.value = playerInfo.exp / playerInfo.nextExp;
    }
}
