using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelixPassed : MonoBehaviour
{
    [SerializeField]
    private int _scoreGain = 2;

    public static event Action<int> _onHelixPassed;

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player != null)
        {
            _onHelixPassed?.Invoke(_scoreGain);
        }
    }
}
