using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatUIManager : MonoBehaviour
{
    private StatModule statModule;

    private void Start()
    {
        statModule = new StatModule();

        var characterSelector = this.GetComponent<CharacterSelectorUI>();
        characterSelector.Init();
        var weaponSelectcor = this.GetComponent<WeaponSelectorUI>();
        weaponSelectcor.Init();

        this.GetComponent<StatDisplayUI>().Init(characterSelector, weaponSelectcor, statModule);
    }
}
