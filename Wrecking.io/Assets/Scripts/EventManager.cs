using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static Action<float> OnDragEvent;

    public static void CallOnDragEvent(float xDelta)
    {
        if(OnDragEvent != null) OnDragEvent(xDelta);
    }
}
