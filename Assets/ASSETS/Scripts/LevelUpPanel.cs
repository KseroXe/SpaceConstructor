using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void OnEnable()
    {
        GlobalEventManager.LevelUp += Show;
        ModuleSelectionButton.ModuleSelected += Hide;
    }

    private void OnDisable()
    {
        GlobalEventManager.LevelUp -= Show;
        ModuleSelectionButton.ModuleSelected -= Hide;
    }

    private void Start()
    {
        panel.SetActive(false) ;
    }

    private void Show()
    {
        panel.SetActive(true);
    }

    private void Hide(ModuleInfo _)
    {
        panel.SetActive(false);
    }
}
