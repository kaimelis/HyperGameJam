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

    public void Create(Vector3 pos, Quaternion rot, Transform parent, SliceType sliceType, GameObject pref)
    {
        this.sliceType = sliceType;
        obj = Instantiate(pref, pos, rot, parent);
        obj.transform.GetChild(0).gameObject.AddComponent(typeof(MeshCollider));
    }

    public abstract void Activate();

}
