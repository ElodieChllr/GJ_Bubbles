using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [Header("Data")]
    public SkinDataBase skinDataBaseRef;
    public int currentMoney;


    [SerializeField] GameObject parentSlotBuy;

    [Header("Buy Panel")]
    [SerializeField] GameObject slotBuy;
    [SerializeField] public TextMeshProUGUI txt_money;
    [SerializeField] bool canBuy = true;

    public bool selected;
    [SerializeField] public static List<SkinData> _slotDatas = new();
    
    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Pieces", 0); // 0 est la valeur par défaut si "Pieces" n'existe pas

        // Utilisez la valeur récupérée (par exemple, l'afficher dans la console)
        Debug.Log("Nombre de pièces récupérées : " + currentMoney);
        txt_money.text = currentMoney.ToString();

        IniBuyPanel();
    }


    private void Update()
    {
        if (currentMoney <= 0)
        {
            canBuy = false;
        }
        else
            canBuy = true;


    }

    private void IniBuyPanel()
    {
        foreach (var data in skinDataBaseRef.datas)
        {
            if (!data.buyable)
                continue;

            var newSlot = Instantiate(slotBuy, parentSlotBuy.transform);

            Button slotButton = newSlot.GetComponentInChildren<Button>(); // Trouver le bouton dans le nouveau panneau

            if (slotButton != null)
            {
                slotButton.onClick.AddListener(() => OnSlotSelected(data)); // Associer la méthode OnSlotSelected au clic du bouton
            }
            else
            {
                Debug.LogError("Le bouton n'a pas été trouvé dans le nouveau panneau !");
            }

            if (newSlot.TryGetComponent<SlotController>(out var sc))
            {
                sc.onSelect += () => OnSlotSelected(data);
                InitSlotBuy(sc, data);
            }
        }
    }

    public void OnBuy()
    {
        if (currentMoney < _slotDatas[0].price)
        {
            canBuy = false;
        }

        if (canBuy == true)
        {
            if (_slotDatas.Count <= 0)
                return;

            currentMoney -= _slotDatas[0].price;
            _slotDatas[0].available = true;
            if (_slotDatas[0].available == true)
            {
                Debug.Log("Available");
            }
            txt_money.text = currentMoney.ToString();
            _slotDatas.Clear();
        }
    }

    private void InitSlotBuy(SlotController slot, SkinData data)
    {
        SetMaskableGraphicValue(ref slot.txt_caption, data.caption);
        SetMaskableGraphicValue(ref slot.txtPrice, data.price);
        SetMaskableGraphicValue(ref slot.img_Item, data.sprite);
    }

    public void OnSlotSelected(SkinData data)
    {
       _slotDatas.Clear();
       _slotDatas.Add(data);       
    }

    private void SetMaskableGraphicValue(ref MaskableGraphic mg, object value)
    {

        switch (mg)
        {
            case TextMeshProUGUI txt: txt.text = value.ToString(); break;
            case TMP_Text txt: txt.text = value.ToString(); break;
            case Text txt: txt.text = value.ToString(); break;


            case Image img: img.sprite = value as Sprite; break;
            case RawImage img: img.texture = value as Texture; break;
        }
    }






}
