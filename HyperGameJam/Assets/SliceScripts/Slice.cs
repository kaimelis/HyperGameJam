using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SliceType
{
    DEADLY,
    NORMAL,
    REWARD,
    STONE,
}
public class Slice : MonoBehaviour
{
    public SliceType sliceType;
    public GameObject obj;

    public void Create(Vector3 pos, Quaternion rot, Transform parent, SliceType sliceType, GameObject pref)
    {
        this.sliceType = sliceType;
        obj = Instantiate(pref, pos, rot, parent);
        obj.AddComponent(typeof(MeshCollider));
    }
}
