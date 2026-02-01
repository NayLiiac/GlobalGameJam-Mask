using TMPro;
using UnityEngine;

public class PlayerStatsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI ClickCountUI;
    //public TextMeshProUGUI TotalClickCount;
    public TextMeshProUGUI ClickPerSeconds;

    [SerializeField]
    private PlayerStats PStats;

    private void Start()
    {
        PStats.UpdateClickCount += UpdateClickCountUI; 
        //PStats.UpdateTotalClickCount += UpdateTotalClickCountUI;

        PStats.UpdateClickRatio += UpdateClickingRatio;

        UpdateClickCountUI(PStats.GetClickCount());
        //UpdateTotalClickCountUI(PStats.GetTotalClickCount());
        UpdateClickingRatio(PStats.GetClickPerSeconds());
    }

    private void UpdateClickCountUI(int amount)
    {
        ClickCountUI.text = "Nombre de Masques : " + amount.ToString();
    }

    /*
    private void UpdateTotalClickCountUI(int amount)
    {
        TotalClickCount.text = "Masques totaux : " + amount.ToString();
    }
    */

    private void UpdateClickingRatio(int amount)
    {
        ClickPerSeconds.text = "Masques par Secondes : " + amount.ToString();
    }


}
