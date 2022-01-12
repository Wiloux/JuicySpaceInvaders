using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuicinessManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            AudioManager.Instance.stopAllAudios = !AudioManager.Instance.stopAllAudios;

        if (Input.GetKeyDown(KeyCode.F2))
            CameraShake.Instance.stopShake = !CameraShake.Instance.stopShake;

        if (Input.GetKeyDown(KeyCode.F3)) {
            ParticlesManager.Instance.stopParticles = !ParticlesManager.Instance.stopParticles;
            if (ParticlesManager.Instance.stopParticles)
                ParticlesManager.Instance.DisableAllActiveParticles();
            else
                ParticlesManager.Instance.EnableAllStoppedParticles();
        }
    }
}