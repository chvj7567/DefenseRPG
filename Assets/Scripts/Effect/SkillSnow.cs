using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSnow : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        MainManager.Audio.Play("Snow", Define.Audio.Effect);
    }
}
