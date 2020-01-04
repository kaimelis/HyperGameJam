using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public static Action<int> _onHelixDestroyed;

    [SerializeField]
    public ParticleSystem particles;

    [SerializeField]
    protected int _scoreGain = 5;
    [SerializeField]
    protected int _health = 2;

    public Slice Create(Vector3 pos, Quaternion rot, Transform parent ,System.Type type, GameObject pref)
    {
        obj = Instantiate(pref, pos, rot, parent);

        return (Slice)obj.transform.GetChild(0).gameObject.GetComponent(type);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Activate(collision);

        particles?.Play();
    }

    public abstract void Activate(Collision collision);

}
