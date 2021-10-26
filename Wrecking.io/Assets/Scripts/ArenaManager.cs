using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] List<SectionManager> sectionManagers;

    private void OnEnable()
    {
        EventManager.OnShrinkTimeEvent += DestroySection;
    }

    private void OnDisable()
    {
        EventManager.OnShrinkTimeEvent -= DestroySection;
    }

    private void DestroySection(int sectionIndex)
    {
        Debug.Log("Destroy " + sectionIndex);
        StartCoroutine(sectionManagers[sectionIndex - 1].DestroyParts());
    }
}
