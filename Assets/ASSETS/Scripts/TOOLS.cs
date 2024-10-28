using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TOOLS
{
    public static Vector2 GetWorldMousePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
