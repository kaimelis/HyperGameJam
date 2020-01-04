using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HelixPartOre : MonoBehaviour
{
    [SerializeField]
    private int _scoreGain = 5;
    [SerializeField]
    private int _health = 2;

    public static event Action<int> _onHelixDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();

        if (player != null)
        {
            _health -= 1;
            if(_health <= 0)
            {
                Destroy(gameObject);
                _onHelixDestroyed?.Invoke(_scoreGain);
            }
        }
    }
}
