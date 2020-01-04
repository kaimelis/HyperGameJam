using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LevelDesigner : MonoBehaviour
{
    public int pieCount;
    public GameObject pref;

    private const int pieSlicesPerPie = 8;
    const float degreePerSlice = 360 / pieSlicesPerPie;

    private const float gap = -5f;

    private List<List<GameObject>> level;

    private Transform parent;
    public void Generate()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);

        parent = new GameObject().transform;

        level = new List<List<GameObject>>();
        for (int i = 0; i < pieCount; i++)
        {
            CreatePie(i);
        }
    }

    void CreatePie(int pieId)
    {
        level.Add(new List<GameObject>());
        for (int i = 0; i < pieSlicesPerPie; i++)
        {
            GameObject slice = Instantiate(pref,new Vector3(0,pieId * gap,0), Quaternion.Euler(new Vector3(0, i * degreePerSlice, 0)));
            slice.transform.parent = parent;
            level[pieId].Add(slice);
        }
    }

    void CreateMidPole()
    {

    }
}
