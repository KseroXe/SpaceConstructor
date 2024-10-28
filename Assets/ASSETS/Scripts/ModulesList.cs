using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ModulesList : MonoBehaviour
{
    public static ModulesList Instance;

    [SerializeField] private ModuleInfo[] modules;
    public ModuleInfo[] Modules => modules;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
