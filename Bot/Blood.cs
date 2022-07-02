using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public ParticleSystem[] particleSystems;


    public void Play()
    {
        foreach (ParticleSystem particle in particleSystems)
            particle.Play();
    }
}
