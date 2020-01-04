using System;
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
public abstract class Slice : MonoBehaviour
{
    public SliceType sliceType;
    public GameObject obj;

    public Slice Create(Vector3 pos, Quaternion rot, Transform parent ,System.Type type, GameObject pref)
    {
        obj = Instantiate(pref, pos, rot, parent);

        return (Slice)obj.transform.GetChild(0).gameObject.GetComponent(type);
    }

    public abstract void Activate();

}
