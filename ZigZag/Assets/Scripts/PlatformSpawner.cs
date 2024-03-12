using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject platform;
    [SerializeField] GameObject diamond;

    [Header("Settings")]
    [SerializeField] bool isGameOver;
    private float size;
    Vector3 lastPos;
    void Start()
    {
        lastPos = platform.transform.position; 
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }

    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatform", 2f, 0.2f);
    }

    void Update()
    {
        if (GameManager.instance.isGameOver ==true)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    private void SpawnPlatform()
    {

        int rand = Random.Range(0, 6);
        if(rand  < 3 )
        {
            SpawnX();
        }
        else if(rand >= 3 )
        {
            SpawnZ();   
        }
    }

    private void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform,pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1 )
        {
            Instantiate(diamond,new Vector3(pos.x,pos.y+1.2f,pos.z), diamond.transform.rotation);
        }

    }

    private void SpawnZ() 
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1.2f, pos.z), diamond.transform.rotation);
        }
    }
}
