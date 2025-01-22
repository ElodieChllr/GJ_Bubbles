using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    [Header("SkinsSystem")]
    public SkinData skinsData;
    private int selectedOption = 0;

    [Header("Ref")]
    public SkinDataBase skinsDataBaseRef;
    public PlayerController playerControllerRef;

    public GameObject slotSkinAvailable;
    public GameObject parentSlotEquip;


    [SerializeField] public static List<SkinData> _slotSkins = new();

    void Start()
    {

        

        IniBuyPanel();
    }

    // Update is called once per frame
    void Update()
    {

    }    

    
    public void SkinAvailable()
    {
        IniBuyPanel();
        
    }


    public void EquipSkin()
    {
        SkinData selectedSkin = _slotSkins[0];


        foreach (var skin in skinsDataBaseRef.datas)
        {
            if (skin != selectedSkin)
            {
                skin.onPlayer = false;
            }
        }

        if(skinsData.color == SkinData.ColorSkin.Orange)
        {
            playerControllerRef.skinOrange.SetActive(true);
            playerControllerRef.skinBleu.SetActive(false);
            playerControllerRef.skinRouge.SetActive(false);
        }
        if (skinsData.color == SkinData.ColorSkin.Bleu)
        {
            playerControllerRef.skinOrange.SetActive(false);
            playerControllerRef.skinBleu.SetActive(true);
            playerControllerRef.skinRouge.SetActive(false);
        }
        if (skinsData.color == SkinData.ColorSkin.Rouge)
        {
            playerControllerRef.skinOrange.SetActive(false);
            playerControllerRef.skinBleu.SetActive(false);
            playerControllerRef.skinRouge.SetActive(true);
        }
        //playerController.playerSpriteRenderer.color = _slotSkins[0].colorSkin;
        //playerControllerRef.sr_player.sprite = _slotSkins[0].sprite;
        //Debug.Log(_slotSkins[0].sprite);

        //selectedSkin.onPlayer = true;

        //if(selectedSkin.Bonuslife > 0)
        //{
        //    selectedSkin.availableBonusLives = selectedSkin.Bonuslife;
        //}
    }
    

    private void IniBuyPanel()
    {
        foreach (var data in skinsDataBaseRef.datas)
        {
            if (!data.available)
                continue;

            var newSlot = Instantiate(slotSkinAvailable, parentSlotEquip.transform);

            Button slotButton = newSlot.GetComponentInChildren<Button>(); // Trouver le bouton dans le nouveau panneau

            if (slotButton != null)
            {
                slotButton.onClick.AddListener(() => OnSlotSelectedSkin(data)); // Associer la méthode OnSlotSelected au clic du bouton
            }
            else
            {
                Debug.LogError("Le bouton n'a pas été trouvé dans le nouveau panneau !");
            }

            if (newSlot.TryGetComponent<SlotController>(out var sc))
            {
                InitSlotBuy(sc, data);
            }
        }
    }
    public void OnSlotSelectedSkin(SkinData data)
    {
        _slotSkins.Clear();
        _slotSkins.Add(data);        
    }

    private void InitSlotBuy(SlotController slot, SkinData data)
    {
        SetMaskableGraphicValue(ref slot.txt_caption, data.caption);
       // SetMaskableGraphicValue(ref slot.img_Item, data.sprite);
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
