using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SliceReward : Slice
{
    public override void Activate(Collision collision)
    {
        _health -= 1;

        if (_health <= 0)
        {
            Destroy(gameObject);
            _onHelixDestroyed?.Invoke(_scoreGain);
        }
    }
}
