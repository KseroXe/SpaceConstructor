using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Module : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool Preplaced = false;

    [Header("References")]
    [SerializeField] private Transform[] moduleSlots;
    
    protected bool placed;
    public bool Placed => placed;

    /*
    private bool _canBePlaced;
    public bool CanBePlaced => _canBePlaced;
    */
    
    private void Start()
    {
        if (Preplaced)
        {
            placed = true;
        }
        else
        {
            foreach (Transform slot in moduleSlots)
            {
                slot.gameObject.SetActive(false);
            }
        }
    }

    public void Place()
    {
        placed = true;
        foreach (Transform slot in moduleSlots)
        {
            slot.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (placed)
        {
            if (collision.gameObject.TryGetComponent<ModuleSlot>(out ModuleSlot slot))
            {
                Debug.Log("Slot deactivated");
                slot.gameObject.SetActive(false);
            }
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Module>(out Module _))
        {
            _canBePlaced = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Module>(out Module _))
        {
            _canBePlaced = true;
        }
    }
    */
}
