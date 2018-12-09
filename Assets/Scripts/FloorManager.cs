using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

    public ParticleSystem particles;


    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Crate")
        {
            ParticleSystem spawnparticle = Instantiate(particles, col.transform.position,Quaternion.identity) as ParticleSystem;
            Destroy(col.gameObject);
            Destroy(spawnparticle.gameObject, spawnparticle.main.duration);
        }
    }

    
}
