using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Crate crate;
    public float crateCount;
    public float timeBetweenSpawn = 2;
    public float nextSpawnTime;

	// Use this for initialization
	void Start () {
    
            
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > nextSpawnTime)
        {
            Crate spawnedCrate = Instantiate(crate, transform.position, Quaternion.identity) as Crate;
            nextSpawnTime = Time.time + timeBetweenSpawn;
        }
		
	}
}
