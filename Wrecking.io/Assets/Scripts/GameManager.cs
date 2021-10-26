using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] float areaShrinkTime;
    [SerializeField] int sectionNumber;

    void Start()
    {
        StartCoroutine(AreaShrinkTimer());
    }

    private IEnumerator AreaShrinkTimer()
    {
        while (sectionNumber > 0)
        {
            yield return new WaitForSecondsRealtime(areaShrinkTime);

            EventManager.CallOnShrinkTimeEvent(sectionNumber);

            sectionNumber--;
        }
    }
}
