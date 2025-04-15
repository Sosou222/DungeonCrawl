using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private static bool active = true;
    public static void SetActiveInput(bool activeState)
    {
        active = activeState;
    }
    public static float GetHorizontal()
    {
        if (!active) return 0.0f;

        float x = 0.0f;
        if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -1.0f;
        }
        return x;
    }

    public static float GetVertical()
    {
        if (!active) return 0.0f;

        float y = 0;
        if (Input.GetKeyDown(KeyCode.W))
        {
            y = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            y = -1.0f;
        }
        return y;
    }
}
