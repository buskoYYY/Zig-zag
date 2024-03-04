using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject platform;

    [Header("Settings")]
    private float size;
    Vector3 lastPos;
    void Start()
    {
        lastPos = platform.transform.position; 
        size = platform.transform.localScale.x;

        for (int i = 0; i < 5; i++)
        {
            SpawnX();
        }
    }

    void Update()
    {
        
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;

        Instantiate(platform,pos, Quaternion.identity);
    }

    private void SpawnZ() 
    { 

    }
}
