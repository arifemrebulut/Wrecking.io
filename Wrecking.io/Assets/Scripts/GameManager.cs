using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] float areaShrinkTime;

    public int sectionNumber;

    public float centerRange;
    public float section1Range;
    public float section2Range;
    public float section3Range;
    public float section4Range;
    public float section5Range;

    #region Debug Settings
    [Header("Debug Settings")]
    [SerializeField] private bool showDebugSpheres;
    #endregion

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

    private void OnDrawGizmos()
    {
        if (showDebugSpheres)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, section5Range);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, section4Range);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, section3Range);

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, section2Range);

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, section1Range);

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, centerRange);
        }
    }
}
