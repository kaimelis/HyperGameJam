using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelixGoal : MonoBehaviour
{
    public event Action _onLevelFinished;

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            _onLevelFinished?.Invoke();
        }
    }
}
