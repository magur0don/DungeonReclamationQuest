using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : SingletonMonoBehaviour<ParticleManager>
{

    public List<GameObject> mainGameParticles = new List<GameObject>();

    public enum MainGameParticlesType
    {
        Invalide = -1,
        LidEffect
    }

    public void SetMainGameParticles(List<GameObject> particles)
    {
        mainGameParticles = particles;
    }

    /// <summary>
    /// ���܂������̃G�t�F�N�g���Đ�����
    /// </summary>
    /// <param name="mainGameParticleType"></param>
    /// <param name="parentTransform"></param>
    public void LidEffectPlay(MainGameParticlesType mainGameParticleType, Vector3 position)
    {
        var effect = Instantiate(mainGameParticles[(int)mainGameParticleType], position, Quaternion.identity);
        effect.SetActive(true);
    }

}
