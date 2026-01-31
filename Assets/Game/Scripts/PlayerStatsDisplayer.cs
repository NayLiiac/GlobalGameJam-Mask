using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI ClickCountUI;
    public TextMeshProUGUI TotalClickCount;
    public TextMeshProUGUI ClickPerSeconds;

    [SerializeField]
    private PlayerStats PStats;

    private void Start()
    {
        PStats.UpdateClickCount += UpdateClickCountUI; 
        PStats.UpdateTotalClickCount += UpdateTotalClickCountUI;

        PStats.UpdateClickRatio += UpdateClickingRatio;

        UpdateClickCountUI(0);
        UpdateTotalClickCountUI(0);
    }

    private void UpdateClickCountUI(int amount)
    {
        ClickCountUI.text = "Click Count : " + amount.ToString();
    }

    private void UpdateTotalClickCountUI(int amount)
    {
        TotalClickCount.text = "Total Click Count : " + amount.ToString();
    }

    private void UpdateClickingRatio(int amount)
    {
        ClickPerSeconds.text = "Click per Seconds : " + amount.ToString();
    }


}
