using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Vector3 _baseScaleValue;
    [SerializeField]
    public Vector3 ScaleModifier;


    private void Start()
    {
        _baseScaleValue = this.transform.localScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = _baseScaleValue;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = ScaleModifier;
    }
}
