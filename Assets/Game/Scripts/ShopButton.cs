using UnityEngine;
using UnityEngine.Rendering;

public class ShopButton : ShopController
{
    [SerializeField]
    private bool _isMaskElement;
    [SerializeField]
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        base.InitializeButton();
        SetButton(false);
    }

    public override void BuyItem()
    {
        if (!_isMaskElement) 
        {
            base.BuyItem();
        }
        else
        {
            if (PStats.GetClickCount() < CurrentPrice)
            {
                Debug.Log("Pas assez de clicks");
                //Debug.Log(CurrentPrice);
                //Debug.Log(PStats.GetClickCount());
            }
            else
            {
                Debug.Log("Bought");
                // Activer event "Mask element Bought"
                UpdatePriceButton(CurrentPrice);
                ApplyClickerValue(ClickerValue);
                PStats.SetMilestone();
                switch(PStats.CheckMilestone())
                {
                    case true: SetButton(true); break;
                    case false: SetButton(false); break;
                }
            }
        }
    }

    public override void RatioRequiredMet(int amount)
    {
        SetButton(true);
    }


    public void SetButton(bool b)
    {
        if(_isMaskElement)
        {
            switch (b)
            {
                case true:
                    this.ShopButton.interactable = true;
                    ChangeDisabledButtonColor(UnlockedButtonColor, this.ShopButton);
                    _canvasGroup.alpha = 1f;
                    break;

                case false:
                    this.ShopButton.interactable = false;
                    base.ChangeDisabledButtonColor(LockedButtonColor, this.ShopButton);
                    _canvasGroup.alpha = 0.3f;
                    break;
            }

        }
        
    }
}
