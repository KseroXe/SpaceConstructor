using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSlot : MonoBehaviour
{
    [SerializeField] private Transform parentModule;
    public Transform ParentModule => parentModule;

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Module>(out Module module))
        {
            if (module.Placed)
            {
                gameObject.SetActive(false);
            }
        }
    }
    */
}
