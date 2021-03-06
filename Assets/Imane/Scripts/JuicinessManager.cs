using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuicinessManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.stopAllAudios = !AudioManager.Instance.stopAllAudios;
        CameraShake.Instance.stopShake = !CameraShake.Instance.stopShake;
        ParticlesManager.Instance.stopParticles = !ParticlesManager.Instance.stopParticles;
        if (ParticlesManager.Instance.stopParticles)
            ParticlesManager.Instance.DisableAllActiveParticles();
        else
            ParticlesManager.Instance.EnableAllStoppedParticles();
        RetroEffectManager.instance.StartStopAllRetroEffects();
        AnimatorManager.Instance.StartStopAnim();
        FontManager.Instance.ChangeAllFont();
    }

    private void Awake()
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

        if (Input.GetKeyDown(KeyCode.F4))
        {
            RetroEffectManager.instance.StartStopAllRetroEffects();
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            AnimatorManager.Instance.StartStopAnim();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            FontManager.Instance.ChangeAllFont();
        }
    }
}
