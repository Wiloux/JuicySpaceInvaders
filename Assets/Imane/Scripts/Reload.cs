using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public ParticleSystem energyParticles;
    void Start()
    {
        ParticlesManager.Instance.PlayParticle(energyParticles, energyParticles.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
