using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/Module Info")]
public class ModuleInfo : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Image;
    public GameObject Prefab;
}
