using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Equip[] curEquips = new Equip[(int)EquipType.Max];
    public Transform[] equipParents = new Transform[(int)EquipType.Max];

    // singleton
    public static EquipManager instance;
    [SerializeField]
    private CharacterStatsSO _addStats;

    private void Awake()
    {
        instance = this;
        UpdateStats();
    }

    public void EquipNew(EquipItem item)
    {
        UnEquip((int)item.type);
        curEquips[(int)item.type] = Instantiate(item.equipPrefab, equipParents[(int)item.type]).GetComponent<Equip>();
        UpdateStats();
    }

    public void UnEquip(int index)
    {
        if (curEquips[index] != null)
        {
            Destroy(curEquips[index].gameObject);
            curEquips[index] = null;
        }
        UpdateStats();
    }

    private void UpdateStats()
    {
        _addStats.Hp = 0;
        _addStats.Atk = 0;
        _addStats.Def = 0;
        _addStats.Speed = 0;
        _addStats.Range = 0;
        _addStats.AtkSpeed = 0;
        foreach (Equip equip in curEquips)
        {
            if(equip != null)
            {
                EquipItem equipItem = equip.equipItem;

                for (int i = 0; i < equipItem.stats.Length; i++)
                {
                    switch (equipItem.stats[i].type)
                    {
                        case StatsType.Hp:
                            _addStats.Hp += equipItem.stats[i].value;
                            break;
                        case StatsType.Atk:
                            _addStats.Atk += equipItem.stats[i].value;
                            break;
                        case StatsType.Def:
                            _addStats.Def += equipItem.stats[i].value;
                            break;
                        case StatsType.Speed:
                            _addStats.Speed += equipItem.stats[i].value;
                            break;
                        case StatsType.Range:
                            _addStats.Range += equipItem.stats[i].value;
                            break;
                        case StatsType.AtkSpeed:
                            _addStats.AtkSpeed += equipItem.stats[i].value;
                            break;
                    }
                }
            }
        }
    }   
}
