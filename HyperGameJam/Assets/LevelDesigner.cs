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
    private GameObject pole;
    private Transform parent;
    public void Generate()
    {
        if (parent != null)
            DestroyImmediate(parent.gameObject);

        if(pole != null)
            DestroyImmediate(pole);

        parent = new GameObject().transform;

        level = new List<List<GameObject>>();
        for (int i = 0; i < pieCount; i++)
        {
            CreatePie(i);
        }

        CreateMidPole(pieCount);
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

    void CreateMidPole(int pieCount )
    {
        pole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        pole.transform.localScale =new Vector3(3, (((pieCount-1) * Mathf.Abs(gap))/2)+2,3);
        pole.transform.localPosition = new Vector3(0, (pieCount-1) * gap / 2, 0);

    }
}
