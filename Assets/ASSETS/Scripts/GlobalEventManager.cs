using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventManager : MonoBehaviour
{
    public static Action LevelUp;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            LevelUp?.Invoke();
        }
    }
}
