using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [SerializeField]
    public PlayerStats PStats;
    [Header("UI Components")]
    public Button ShopButton;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI ShopNameText;
    public Image ShopIcon;
    public TextMeshProUGUI BoughtTimesText;

    [Header("Price Color")]
    [SerializeField]
    private Color _notEnoughClicksColor;
    [SerializeField]
    private Color _enoughClicksColor;

    [Header("Locked Button Color")]
    public Color LockedButtonColor;
    public Color UnlockedButtonColor;

    [Header("Shop Info")]
    [SerializeField]
    private string _shopName = string.Empty;
    [SerializeField]
    private int _basePrice = 5;
    public int CurrentPrice = 0;
    [SerializeField]
    private int _priceCoef = 2;
    [SerializeField]
    private int _boughtTimes = 0;
    [SerializeField]
    public int ClickerValue = 0;

    public virtual void InitializeButton()
    {
        CurrentPrice = _basePrice;
        ShopNameText.text = _shopName;
        PriceText.text = _basePrice.ToString();
        if(BoughtTimesText != null )
        {
            BoughtTimesText.text = _boughtTimes.ToString();
        }

        PStats.UpdateClickCount += UpdatePriceColor;
        PStats.RatioRequiredMetEvent += RatioRequiredMet;
        UpdatePriceColor(PStats.GetClickCount());
    }

    public virtual void BuyItem()
    {
        if (PStats.GetClickCount() < CurrentPrice)
        {

        }
        else
        {
            UpdatePriceButton(CurrentPrice);
            ApplyClickerValue(ClickerValue);
        }
    }

    public virtual void UpdatePriceButton(int amount)
    {
        PStats.RemoveClickCount(amount);
        UpdatePriceColor(PStats.GetClickCount());
        CurrentPrice = _basePrice + amount + _priceCoef;
        _boughtTimes++;
        UpdateShop();
    }

    public virtual void ApplyClickerValue(int amount)
    {
        PStats.IncreaseClickingRate(amount);
    }

    public abstract void RatioRequiredMet(int amount);

    #region Customization
    public virtual void UpdatePriceColor(int i)
    {
        if(i < CurrentPrice)
        {
            PriceText.color = _notEnoughClicksColor;
        }
        else
        {
            PriceText.color = _enoughClicksColor;
        }
    }

    public virtual void UpdateShop()
    {
        if(BoughtTimesText != null)
        {
            BoughtTimesText.text = _boughtTimes.ToString();
        }
        PriceText.text = CurrentPrice.ToString();
    }

    public virtual void ChangeDisabledButtonColor(Color color, Button button)
    {
        ColorBlock cb = button.colors;
        cb.disabledColor = color;
        button.colors = cb;
    }
    #endregion
}