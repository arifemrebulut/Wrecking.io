using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    public static Action<float> OnDragEvent;
    public static Action<int> OnShrinkTimeEvent;

    public static void CallOnDragEvent(float xDelta)
    {
        if(OnDragEvent != null) OnDragEvent(xDelta);
    }

    public static void CallOnShrinkTimeEvent(int sectionNumber)
    {
        if (OnShrinkTimeEvent != null) OnShrinkTimeEvent(sectionNumber);
    }
}
