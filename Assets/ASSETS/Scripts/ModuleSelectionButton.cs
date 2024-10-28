using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ModuleSelectionButton : MonoBehaviour
{
    public static Action<ModuleInfo> ModuleSelected;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image image;
    private ModuleInfo _moduleInfo;

    private void OnEnable()
    {
        GlobalEventManager.LevelUp += RandomizeModule;
    }

    private void OnDisable()
    {
        GlobalEventManager.LevelUp -= RandomizeModule;
    }

    private void Start()
    {
        RandomizeModule();
    }

    private void RandomizeModule()
    {
        int randomIndex = UnityEngine.Random.Range(0, ModulesList.Instance.Modules.Length);
        ModuleInfo newModuleInfo = ModulesList.Instance.Modules[randomIndex];
        _moduleInfo = newModuleInfo;

        UpdateUI();
    }

    private void UpdateUI()
    {
        titleText.text = _moduleInfo.Name;
        descriptionText.text = _moduleInfo.Description;
        image.sprite = _moduleInfo.Image;
    }
    public void SelectModule()
    {
        ModuleSelected?.Invoke(_moduleInfo);
    }
}
