using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public bool spawned;
    public int spawnCount; 

    [SerializeField] Transform[] spawnLocation;
    [SerializeField] GameObject spawnTarget;

  
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (!spawned)
        {
            spawnCount = spawnLocation.Length - Mathf.Abs(Random.Range(2, 8));
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnHere = spawnLocation[i].position;
                Instantiate(spawnTarget, spawnHere, transform.rotation);

            } 
            spawned = true;
        }   
    }
}
