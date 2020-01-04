using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    public void SetAudioPlay(float level)
    {
        audioSource.pitch = level;
        audioSource.Play();
    }
    public void PlayRandomPitch()
    {
        //audio pitch(range 0.5 x to 2.0 x, default 1.0 x).
        //audioSource.pitch = Random.Range(0.5f, 2f);
        audioSource.pitch = Random.Range(-3f, 3f);
        audioSource.Play();
    }
}
