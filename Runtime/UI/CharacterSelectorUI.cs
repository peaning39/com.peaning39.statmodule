using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UniRx;

public class CharacterSelectorUI : MonoBehaviour
{
    public Transform characterListContent;
    public GameObject characterButtonPrefab;

    public List<CharacterStatData> characterDataList;

    public ReactiveProperty<CharacterStatData> SelectedCharacter { get; private set; } = new();
    private Dictionary<string, CharacterStatData> characterDict = new();

    private string characterKey = "";

    public void Init()
    {
        foreach (var data in characterDataList)
        {
            characterDict[data.characterKey] = data;

            var btnObj = Instantiate(characterButtonPrefab, characterListContent);
            var btn = btnObj.GetComponent<Button>();
            var label = btnObj.GetComponentInChildren<Text>();
            label.text = data.characterKey;

            btn.onClick.AddListener(() => SelectCharacter(data.characterKey));

            if (characterKey == string.Empty)
                btn.onClick.Invoke();
        }
    }

    void SelectCharacter(string CharacterKey)
    {
        characterKey = CharacterKey;
        Debug.Log($"Selected character: {CharacterKey}");

        if (characterDict.TryGetValue(CharacterKey, out var statData))
        {
            SelectedCharacter.Value = statData;
        }
    }
}