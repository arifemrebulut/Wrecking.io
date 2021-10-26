using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    private List<GameObject> sectionParts = new List<GameObject>();

    private void Start()
    {
        foreach (var part in transform.GetComponentsInChildren<Transform>())
        {
            sectionParts.Add(part.gameObject);
        }
    }

    public IEnumerator DestroyParts()
    {
        foreach (GameObject part in sectionParts)
        {
            part.AddComponent<Rigidbody>();

            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        }
    }
}
