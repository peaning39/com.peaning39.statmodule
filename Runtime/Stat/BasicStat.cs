using System.Collections.Generic;
using System;
using UniRx;

public class BasicStat
{
    private Dictionary<string, double> basicStatValue;
    private Subject<string> subject;

    public BasicStat(Subject<string> subject)
    {
        basicStatValue = new Dictionary<string, double>();
        this.subject = subject;
    }

    public void SetBasicStats(CharacterStatData statData)
    {
        SetStat(StatDefine.HealthPoint, statData.HP);
        SetStat(StatDefine.BaseAttack, statData.ATK);
        SetStat(StatDefine.AttackScale, statData.ATKScale);
        SetStat(StatDefine.AttackSpeed, statData.AttackSpeed);
    }

    private void SetStat(string key, string value)
    {
        if (!double.TryParse(value, out var parsed))
            parsed = 0.0;

        basicStatValue[key] = parsed;
        subject.OnNext(key);
    }

    public double GetStatValue(string statKey)
    {
        return basicStatValue.TryGetValue(statKey, out var value) ? value : 0.0;
    }
}