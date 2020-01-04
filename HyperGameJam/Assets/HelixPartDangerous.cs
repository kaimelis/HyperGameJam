using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixPartDangerous : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.transform.GetComponent<Player>();

        if(player != null)
            player.Destroy();
    }
}
