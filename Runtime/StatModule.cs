using System;
using System.Collections.Generic;
using UniRx;

public class StatModule
{
    private BasicStat basicStat;
    private WeaponStat weaponStat;

    private Dictionary<string, List<Action<double>>> statLinks;

    private Dictionary<string, double> savedStatDictionary = new Dictionary<string, double>();

    private Subject<string> subject = new Subject<string>();

    private (double Min, double Max) defaultDamage = (0, 0);

    public StatModule()
    {
        subject.Subscribe((value) =>
        {
            SaveStat(value);

            if (StatDefine.IsDamageCalculationStat(value))
            {
                DamageCalculation();
            }
        });

        basicStat = new BasicStat(subject);
        weaponStat = new WeaponStat(subject);
        statLinks = new Dictionary<string, List<Action<double>>>();
    }

    public void SetBasicStat(CharacterStatData Data)
    {
        basicStat.SetBasicStats(Data);
    }

    public void SetWeaponStat(WeaponData Data)
    {
        weaponStat.SetWeaponStat(Data);
    }
    public double GetStatValue(string statKey)
    {
        double basicValue = basicStat.GetStatValue(statKey);
        double weaponValue = weaponStat.GetStatValue(statKey);
        return basicValue + weaponValue;
    }

    public void SetStatLinked(string statKey, Action<double> action)
    {
        if (!statLinks.ContainsKey(statKey))
            statLinks[statKey] = new List<Action<double>>();

        statLinks[statKey].Add(action);
    }

    public void RemoveStatLinked(string statKey, Action<double> action)
    {
        if (statLinks.TryGetValue(statKey, out var actions))
        {
            actions.Remove(action);
        }
    }
    public string GetStatText()
    {
        string returnValue = "";

        foreach (var key in savedStatDictionary.Keys)
        {
            if (savedStatDictionary.TryGetValue(key, out var val))
            {
                string formatted = key switch
                {
                    StatDefine.AttackScale => $"{val}%",
                    _ => val.ToString()
                };
                returnValue += $"{key}: {formatted}\n";
            }
        }
        return returnValue;
    }

    private void SaveStat(string statKey)
    {
        double value = basicStat.GetStatValue(statKey);
        value += weaponStat.GetStatValue(statKey);

        savedStatDictionary[statKey] = value;

        if (statLinks.TryGetValue(statKey, out var actions))
        {
            foreach (var action in actions)
                action.Invoke(value);
        }
    }

    private void DamageCalculation()
    {
        double atk = GetStatValue(StatDefine.AttackScale);
        defaultDamage = (atk, atk);
    }

    public void Clear()
    {
        savedStatDictionary.Clear();
        statLinks.Clear();
    }
}