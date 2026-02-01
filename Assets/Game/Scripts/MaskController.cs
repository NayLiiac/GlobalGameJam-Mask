using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskController : MonoBehaviour
{
    #region Struct
    [System.Serializable]
    public struct MaskElements
    {
        public List<Sprite> ElementList;
    }
    #endregion

    [SerializeField]
    private ShopButton _shopButton;
    [SerializeField]
    private Image _maskPart0, _maskPart1, _maskPart2, _maskPart3, _maskPart4, _maskPart5;
    [SerializeField]
    private CanvasGroup _maskCanva0, _maskCanva1, _maskCanva2, _maskCanva3, _maskCanva4, _maskCanva5;

    [Header("Next Mask Element")]
    public Sprite NextMaskElement;
    public int NextMaskElementLocation;

    [Header("Sprite Container")]
    public List<MaskElements> MaskParts = new List<MaskElements>();

    private List<CanvasGroup> _maskCanvas = new List<CanvasGroup>();
    private List<Image> _maskImages = new List<Image>();

    private void Start()
    {
        _shopButton.MaskPartBoughtEvent += PlaceMaskPart;

        _maskCanvas.Add(_maskCanva0);
        _maskCanvas.Add(_maskCanva1);
        _maskCanvas.Add(_maskCanva2);
        _maskCanvas.Add(_maskCanva3);
        _maskCanvas.Add(_maskCanva4);
        _maskCanvas.Add(_maskCanva5);

        _maskImages.Add(_maskPart0);
        _maskImages.Add(_maskPart1);
        _maskImages.Add(_maskPart2);
        _maskImages.Add(_maskPart3);
        _maskImages.Add(_maskPart4);
        _maskImages.Add(_maskPart5);

        foreach (CanvasGroup canva in  _maskCanvas)
        {
            canva.alpha = 0;
        }
        foreach (Image image in _maskImages)
        {
            image.sprite = null;
        }

        SelectNextPart();
    }

    public void SelectNextPart()
    {
        NextMaskElementLocation = Random.Range(0, MaskParts.Count);
        NextMaskElement = MaskParts[NextMaskElementLocation].ElementList[Random.Range(0, MaskParts[NextMaskElementLocation].ElementList.Count)];
        Debug.Log(NextMaskElement + "+" +  NextMaskElementLocation);
    }

    private void PlaceMaskPart()
    {
        switch(NextMaskElementLocation)
        {
            case 0:
                _maskPart0.sprite = NextMaskElement;
                _maskCanva0.alpha = 1f;
                break;
            case 1:
                _maskPart1.sprite = NextMaskElement;
                _maskCanva1.alpha = 1f;
                break;
            case 2:
                _maskPart2.sprite = NextMaskElement; 
                _maskCanva2.alpha = 1f;
                break;
            case 3:
                _maskPart3.sprite = NextMaskElement;
                _maskCanva3.alpha = 1f; 
                break;
            case 4: 
                _maskPart4.sprite = NextMaskElement; 
                _maskCanva4.alpha = 1f;
                break;
            case 5: 
                _maskPart5.sprite = NextMaskElement;
                _maskCanva5.alpha = 1f;
            break;
        }
        SelectNextPart();
    }
}
