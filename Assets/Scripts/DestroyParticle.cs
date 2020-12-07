using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    //Lets the whole particle effect occur
    void Update()
    {
        if (particleSystem.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
    }

    //Check particle effect has completed
    void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
