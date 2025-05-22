using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "StatSystem/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponKey;

    public List<StatModifier> modifiers = new List<StatModifier>();
}
[System.Serializable]
public class StatModifier
{
    public string statName;
    public float value;
}