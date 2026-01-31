using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Events
    public event Action OnMaskClicked;
    #endregion

    public void MaskClicker()
    {
        OnMaskClicked.Invoke();
    }
}
