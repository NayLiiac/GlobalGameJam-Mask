using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables
    [Header("Variables")]
    [SerializeField]
    [Tooltip("Number of clicks")]
    private int _clickCount = 0;
    [SerializeField]
    private int _totalClickCount = 0;
    [SerializeField]
    private int _clickPerSeconds = 0;
    #endregion

    #region Refs
    [SerializeField]
    private PlayerController PController;
    #endregion

    #region Events
    #region Click Event about adding and removing
    public event Action<int> UpdateClickCount;
    #endregion

    #region Click event about updating
    public event Action<int> UpdateClickRatio;
    public event Action<int> UpdateTotalClickCount;
    #endregion
    #endregion


    private void Start()
    {
        PController.OnMaskClicked += GetClick;
        StartCoroutine(GeneratePassiveIncome(_clickPerSeconds));

    }

    private void GetClick()
    {
        Debug.Log("<color=green>Click</color>");
        _clickCount += 1;
        _totalClickCount += 1;


        UpdateClickCount?.Invoke(_clickCount);
        UpdateTotalClickCount?.Invoke(_totalClickCount);
    }

    public void RemoveClickCount(int amountToRemove)
    {
        _clickCount -= amountToRemove;
        UpdateClickCount?.Invoke(_clickCount);
    }

    public void IncreaseClickingRate(int amount)
    {
        _clickPerSeconds += amount;
        UpdateClickRatio?.Invoke(_clickPerSeconds);
    }

    #region Passive Income
    private IEnumerator GeneratePassiveIncome(int i)
    {
        _clickCount += i;
        yield return new WaitForSeconds(1);
        StartCoroutine(GeneratePassiveIncome(_clickPerSeconds));
    }
    #endregion


    #region Access Variables
    public int GetClickPerSeconds() { return _clickPerSeconds;}

    public int GetTotalClickCount() { return _totalClickCount;}

    public int GetClickCount() { return _clickCount;}
    #endregion
}
