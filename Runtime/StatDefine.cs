using System.Collections.Generic;

public static class StatDefine
{
    public const string HealthPoint = "HP";
    public const string BaseAttack = "ATK";
    public const string AttackScale = "ATKScale";
    public const string AttackSpeed = "AttackSpeed";

    private static readonly Dictionary<string, int> statScales = new()
    {
        { HealthPoint, 1 },
        { BaseAttack, 1 },
        { AttackScale, 100 },
        { AttackSpeed, 100 },
    };

    private static readonly HashSet<string> damageCalculationStat = new()
    {
        BaseAttack,
        AttackScale
    };

    public static bool IsDamageCalculationStat(string statKey)
    {
        return damageCalculationStat.Contains(statKey);
    }

    public static int GetStatScale(string statKey)
    {
        return statScales.TryGetValue(statKey, out var scale) ? scale : 1;
    }

    public static void Clear()
    {
        statScales.Clear();
        damageCalculationStat.Clear();
    }
}