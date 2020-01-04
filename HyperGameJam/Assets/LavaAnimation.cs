using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimation : MonoBehaviour
{
    public float maxOffset = 1.0f;
    public float offsetIncrement = 0.1f;
    public float frameTime = 0.3f;
    private float timer;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = Random.Range(0, 1);
        timer = Random.Range(0, frameTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= frameTime)
        {
            timer = 0;
            offset = (offset + offsetIncrement) % maxOffset;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0.0f);
        }
    }
}
