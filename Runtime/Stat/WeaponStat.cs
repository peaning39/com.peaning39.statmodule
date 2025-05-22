using System.Collections.Generic;
using UniRx;

public class WeaponStat
{
    private readonly Subject<string> subject;
    private WeaponData currentWeapon;

    private readonly Dictionary<string, double> weaponStats = new();

    public WeaponStat(Subject<string> subject)
    {
        this.subject = subject;
    }

    public void SetWeaponStat(WeaponData weaponData)
    {
        currentWeapon = weaponData;
        var previouslyWeaponStats = new List<string>(weaponStats.Keys);
        weaponStats.Clear();

        if (weaponData != null && weaponData.modifiers != null)
        {
            foreach (var modifier in weaponData.modifiers)
            {
                weaponStats[modifier.statName] = modifier.value;
                subject.OnNext(modifier.statName);
                previouslyWeaponStats.Remove(modifier.statName);
            }
        }
        foreach (var statKey in previouslyWeaponStats)
        {
            subject.OnNext(statKey);
        }
    }

    public double GetStatValue(string statKey)
    {
        return weaponStats.TryGetValue(statKey, out var value) ? value : 0.0;
    }
}