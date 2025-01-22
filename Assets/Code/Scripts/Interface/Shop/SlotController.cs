using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotController : MonoBehaviour
{
    public SkinData skinData { get; protected set; }

    public Action onSelect;
    public Action onDeselect;

    [Header("Common : ")]
    [SerializeField] public MaskableGraphic img_Item;
    [SerializeField] public MaskableGraphic txt_caption;

    [Header("SHOP : ")]
    [SerializeField] public MaskableGraphic txtPrice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeselect(BaseEventData eventData)
    {
        onDeselect?.Invoke();
    }

    public void OnSelect(BaseEventData eventData)
    {
        onSelect?.Invoke();
    }


}
