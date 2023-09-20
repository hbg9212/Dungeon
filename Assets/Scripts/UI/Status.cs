using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{

    private PlayerInfoSO playerInfo;

    [SerializeField] private TextMeshProUGUI[] Texts;

    private void OnEnable()
    {

        playerInfo = GameManager.instance.playerInfo;

        CharacterStatsSO baseStats = playerInfo.BaseStats;
        CharacterStatsSO addStats = playerInfo.AddStats;
        string str = "";
        for(int i = 0; i < (int)StatsType.Max; i++)
        {
            switch (i)
            {
                case (int)StatsType.Hp:
                    str = addStats.Hp == 0 ?
                    string.Format($"{baseStats.Hp}") : addStats.Hp > 0 ?
                            string.Format($"{baseStats.Hp} (<color=green>+{addStats.Hp}</color>)") : string.Format($"{baseStats.Hp} (<color=green>{addStats.Hp}</color>)");
                    Texts[i].text = str;
                    break;
                case (int)StatsType.Atk:
                    str = addStats.Atk == 0 ?
                    string.Format($"{baseStats.Atk}") : addStats.Atk > 0 ?
                            string.Format($"{baseStats.Atk} (<color=green>+{addStats.Atk}</color>)") : string.Format($"{baseStats.Atk} (<color=green>{addStats.Atk}</color>)");
                    Texts[i].text = str;
                    break;
                case (int)StatsType.Def:
                    str = addStats.Def == 0 ?
                    string.Format($"{baseStats.Def}") : addStats.Def > 0 ?
                            string.Format($"{baseStats.Def} (<color=green>+{addStats.Def}</color>)") : string.Format($"{baseStats.Def} (<color=green>{addStats.Def}</color>)");
                    Texts[i].text = str;
                    break;
                case (int)StatsType.Speed:
                    str = addStats.Speed == 0 ?
                    string.Format($"{baseStats.Speed}") : addStats.Speed > 0 ?
                            string.Format($"{baseStats.Speed} (<color=green>+{addStats.Speed}</color>)") : string.Format($"{baseStats.Speed} (<color=green>{addStats.Speed}</color>)");
                    Texts[i].text = str;
                    break;
                case (int)StatsType.Range:
                    str = addStats.Range == 0 ?
                    string.Format($"{baseStats.Range}") : addStats.Range > 0 ?
                            string.Format($"{baseStats.Range} (<color=green>+{addStats.Range}</color>)") : string.Format($"{baseStats.Range} (<color=green>{addStats.Range}</color>)");
                    Texts[i].text = str;
                    break;
                case (int)StatsType.AtkSpeed:
                    str = addStats.AtkSpeed == 0 ?
                    string.Format($"{baseStats.AtkSpeed}") : addStats.AtkSpeed > 0 ?
                            string.Format($"{baseStats.AtkSpeed} (<color=green>{addStats.Hp}</color>)") : string.Format($"{baseStats.AtkSpeed} (<color=green>{addStats.AtkSpeed}</color>)");
                    Texts[i].text = str;
                    break;
            }
        }
    }
}
