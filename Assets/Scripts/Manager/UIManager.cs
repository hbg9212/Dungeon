using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private string _name;
    private int _level = 0;
    private float _exp = 0f;
    private float _nextExp;
    private int _gold;

    [SerializeField] private ExpSO expData;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Slider expSlider;

    public void SetName(string name)
    {
        _name = name;
        UIUpdateName();
    }

    public void SetLevel(int level)
    {
        _level = level;
        _nextExp = expData.nextExp[level];
        UIUpdateLevel();
        AddExp(0f);
    }

    public void AddExp(float exp)
    {
        _exp += exp;
        if(_nextExp <= _exp)
        {
            _exp -= _nextExp;
            SetLevel(++_level);
        }
        UIUpdateExp();
    }

    public void AddGold(int gold)
    {
        _gold += gold;
        UIUpdategold();
    }

    private void UIUpdateName()
    {
        nameText.text = _name;
    }

    private void UIUpdateLevel()
    {
        levelText.text = string.Format($"Level {_level}"); 
    }

    private void UIUpdategold()
    {
        goldText.text = string.Format($"{_gold}");
    }

    private void UIUpdateExp()
    {
        expSlider.value = _exp / _nextExp;
    }
}
