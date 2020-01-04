using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SliceDeadly : Slice
{
    public override void Activate(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();
        if(player != null)
            player.Destroy();
    }
}
