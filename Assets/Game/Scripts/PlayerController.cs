using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Events
    public event Action OnMaskClicked;
    #endregion

    public ParticleSystem Particle;
    public Transform Mask;

    public void MaskClicker()
    {
        OnMaskClicked.Invoke();
        MaskSpin();
        Particle.Play();
    }

    public void MaskSpin()
    {
        int i = UnityEngine.Random.Range(0, 2);
        switch (i)
        {
            case 0:
                Mask.eulerAngles += new Vector3(0, 0, 5f);
                break;
            case 1:
                Mask.eulerAngles += new Vector3(0, 0, -5f);
                break;
        }
    }
}
