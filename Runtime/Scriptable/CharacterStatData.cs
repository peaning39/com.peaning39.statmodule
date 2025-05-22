using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatData", menuName = "Stat/Character")]
public class CharacterStatData : ScriptableObject
{
    public string characterKey;

    public string HP;
    public string ATK;
    public string ATKScale;
    public string AttackSpeed;
}