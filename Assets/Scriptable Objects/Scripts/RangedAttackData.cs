using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangedAttackData", menuName = "Info/Attacks/Ranged", order = 1)]
public class RangedAttackData : AttackSO
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfProjectilesPreShot;
    public float multipleProjectilesAngel;
    public Color projectileColor;
}
