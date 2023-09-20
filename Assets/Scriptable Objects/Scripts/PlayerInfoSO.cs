using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfoData", menuName = "Info/CharacterStats/PlayerInfo", order = 0)]
public class PlayerInfoSO : ScriptableObject
{
    public string name;
    public int level;
    public float exp;
    public float nextExp;
    public int gold;

    public CharacterStatsSO BaseStats;
    public CharacterStatsSO AddStats;
}
