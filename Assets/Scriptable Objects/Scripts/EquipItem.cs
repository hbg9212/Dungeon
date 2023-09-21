using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EquipType
{
    Weapon
    , Pitching
    , Armor
    , Shield

    , Max
}

[System.Serializable]
public class EquipItemStats
{
    public StatsType type;
    public float value;
}

[CreateAssetMenu(fileName = "EquipItem", menuName = "Item/EquipItem")]
public class EquipItem : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public EquipType type;
    public Sprite icon;

    [Header("Stats")]
    public EquipItemStats[] stats;

    [Header("Equip")]
    public GameObject equipPrefab;
}
