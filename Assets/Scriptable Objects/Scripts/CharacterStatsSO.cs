using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsType
{
    Hp
    , Atk
    , Def
    , Speed
    , AtkSpeed
    , Range


    , Max
}

[CreateAssetMenu(fileName = "DefaultCharacterStats", menuName = "Info/CharacterStats/CharacterStats", order = 1)]
public class CharacterStatsSO : ScriptableObject
{
    public float MaxHp;
    public float Hp;
    public float Atk;
    public float Def;
    public float Speed;
    public float AtkSpeed;
    public float Range;
}
