using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    ParticleSystem[] _ps;
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        _ps = GetComponentsInChildren<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        foreach (ParticleSystem ps in _ps)
        {
            foreach (ParticleSystem.Particle p in inside)
            {

            }
        }
    }
}
