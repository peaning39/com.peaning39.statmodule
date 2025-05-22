using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UniRx;

public class StatDisplayUI : MonoBehaviour
{
    public Text displayText;

    private string Jop;
    private string Weapon;

    private readonly List<string> statKeys = new()
    {
        StatDefine.HealthPoint,
        StatDefine.BaseAttack,
        StatDefine.AttackScale,
        StatDefine.AttackSpeed,
    };

    private Dictionary<string, double> currentStatValues = new();

    public void Init(CharacterSelectorUI CharacterSelector, WeaponSelectorUI WeaponSelector, StatModule Module)
    {
        CharacterSelector.SelectedCharacter
            .Where(data => data != null)
            .Subscribe(data =>
            {
                Module.SetBasicStat(data);
                Jop = data.characterKey;
                Refresh(Module);
            })
            .AddTo(this);

        WeaponSelector.SelectedWeapon
            .Where(data => data != null)
            .Subscribe(data =>
            {
                Module.SetWeaponStat(data);
                Weapon = data.weaponKey;
                Refresh(Module);
            })
            .AddTo(this);
    }
    private void Refresh(StatModule Module)
    {
        displayText.text = $"Jop : {Jop}\nWeapon : {Weapon}\n{Module.GetStatText()}" ;
        
    }
}