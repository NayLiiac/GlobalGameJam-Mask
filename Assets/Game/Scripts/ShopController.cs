using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats PStats;
    [Header("UI Components")]
    public Button ShopButton;
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI ShopNameText;
    private Image _shopIcon;
    public TextMeshProUGUI BoughtTimesText;

    [Header("Price Color")]
    [SerializeField]
    private Color _notEnoughClicksColor;
    [SerializeField]
    private Color _EnoughClicksColor;

    [Header("Shop Info")]
    [SerializeField]
    private string _shopName = string.Empty;
    [SerializeField]
    private int _basePrice = 5;
    [SerializeField]
    private int _currentPrice = 0;
    [SerializeField]
    public Image ShopIcon;
    [SerializeField]
    private int _priceCoef = 2;
    [SerializeField]
    private int _boughtTimes = 0;
    [SerializeField]
    public int _clickerValue = 0;

    public virtual void InitializeButton()
    {
        _currentPrice = _basePrice;
        ShopNameText.text = _shopName;
        PriceText.text = _basePrice.ToString();
        BoughtTimesText.text = _boughtTimes.ToString();

        PStats.UpdateClickCount += UpdatePriceColor; 
        UpdatePriceColor(PStats.GetClickCount());

        if(_shopIcon != null)
        {
            _shopIcon.sprite = ShopIcon.sprite;
        }
    }

    public virtual void BuyItem()
    {
        if (PStats.GetClickCount() < _currentPrice)
        {
            Debug.Log("Pas assez de clicks");
            Debug.Log(_currentPrice);
            Debug.Log(PStats.GetClickCount());
        }
        else
        {
            Debug.Log("Bought");
            UpdatePriceButton(_currentPrice);
            ApplyClickerValue(_clickerValue);
            
            
        }
    }

    public virtual void UpdatePriceButton(int amount)
    {
        PStats.RemoveClickCount(amount);
        UpdatePriceColor(PStats.GetClickCount());
        _currentPrice = _basePrice + amount * _priceCoef;
        _boughtTimes++;
        UpdateShop();
    }

    public virtual void ApplyClickerValue(int amount)
    {
        PStats.IncreaseClickingRate(amount);
    }

    #region Customization
    public virtual void UpdatePriceColor(int i)
    {
        if(i < _currentPrice)
        {
            PriceText.color = Color.red;
        }
        else
        {
            PriceText.color = Color.green;
        }
    }

    public virtual void UpdateShop()
    {
        BoughtTimesText.text = _boughtTimes.ToString();
        PriceText.text = _currentPrice.ToString();
    }
    #endregion
}