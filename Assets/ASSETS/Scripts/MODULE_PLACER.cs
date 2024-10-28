using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MODULE_PLACER : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int calculationsFrameInterval;
    [SerializeField] private float distanceMaxError;
    private int _currentFrameInterval;

    [Header("Prefabs")]
    [SerializeField] private GameObject modulePrefab1;
    [SerializeField] private GameObject modulePrefab2;
    [SerializeField] private GameObject modulePrefab3;
    private Transform _moduleToPlace;

    private void OnEnable()
    {
        ModuleSelectionButton.ModuleSelected += OnModuleSelected;
    }

    private void OnDisable()
    {
        ModuleSelectionButton.ModuleSelected -= OnModuleSelected;
    }

    private void Update()
    {
        if (_moduleToPlace == null)
        {
            return;
        }
        else 
        {
            _currentFrameInterval++;
            
            if (_currentFrameInterval >= calculationsFrameInterval)
            {
                _currentFrameInterval = 0;

                // Calculations
                 ModuleSlot nearestSlot = SelectCorrectSlot(FindNearestSlots());
                _moduleToPlace.position = nearestSlot.transform.position;
                _moduleToPlace.up = _moduleToPlace.position - nearestSlot.ParentModule.position;
            }

            if (Input.GetMouseButtonDown(0))
            { 
                _moduleToPlace.GetComponent<Module>().Place();
                _moduleToPlace = null;
            }
        }
    }

    private List<ModuleSlot> FindNearestSlots()
    {
        ModuleSlot[] slots = FindObjectsOfType<ModuleSlot>();
        if (slots.Length <= 0)
        {
            Debug.LogWarning("Can't find module slots");
            return null;
        }

        List<ModuleSlot> results = new();
        Vector2 mousePos = TOOLS.GetWorldMousePosition();
        float resultDistance = Vector2.Distance(slots[0].transform.position, mousePos);

        foreach (ModuleSlot slot in slots)
        {
            float newDistance = Vector2.Distance(mousePos, slot.transform.position);
            if (newDistance < resultDistance - distanceMaxError)
            {
                results.Clear();
                results.Add(slot);
                resultDistance = newDistance;
            }
            else if (resultDistance - distanceMaxError <= newDistance && newDistance <= resultDistance + distanceMaxError)
            {
                results.Add(slot);
            }
        }

        Debug.Log(results.Count);
        return results;
    }

    // Selects module slot from a list depending on distance between mouse and parent module
    private ModuleSlot SelectCorrectSlot(List<ModuleSlot> slots)
    {
        if (slots.Count <= 0)
        {
            Debug.LogWarning("No slots were provided");
            return null;
        }
        else if (slots.Count == 1)
        {
            return slots[0];
        }

        ModuleSlot result = slots[0];
        Vector2 mousePos = TOOLS.GetWorldMousePosition();
        float resultDistance = Vector2.Distance(mousePos, slots[0].ParentModule.position);

        foreach (ModuleSlot slot in slots)
        {
            float newDistance = Vector2.Distance(mousePos, slot.ParentModule.position);
            if (newDistance < resultDistance)
            {
                result = slot;
                resultDistance = newDistance;
            }
        }

        return result;
    }

    private void OnModuleSelected(ModuleInfo moduleInfo)
    {
        _moduleToPlace = Instantiate(moduleInfo.Prefab, TOOLS.GetWorldMousePosition(), Quaternion.identity).transform;
    }
}
