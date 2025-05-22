using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UniRx;

public class WeaponSelectorUI : MonoBehaviour
{
    public Transform weaponListContent;
    public GameObject weaponButtonPrefab;

    public List<WeaponData> weaponDataList;

    public ReactiveProperty<WeaponData> SelectedWeapon { get; private set; } = new();
    private Dictionary<string, WeaponData> weaponDict = new();

    private string weaponKey = "";

    public void Init()
    {
        foreach (var data in weaponDataList)
        {
            weaponDict[data.weaponKey] = data;

            var btnObj = Instantiate(weaponButtonPrefab, weaponListContent);
            var btn = btnObj.GetComponent<Button>();
            var label = btnObj.GetComponentInChildren<Text>();
            label.text = data.weaponKey;

            btn.onClick.AddListener(() => SelectWeapon(data.weaponKey));
            if (weaponKey == string.Empty)
                btn.onClick.Invoke();
        }
    }

    void SelectWeapon(string WeaponName)
    {
        weaponKey = WeaponName;
        Debug.Log($"Selected weapon: {WeaponName}");

        if (weaponDict.TryGetValue(WeaponName, out var weaponData))
        {
            SelectedWeapon.Value = weaponData;
        }
    }
}