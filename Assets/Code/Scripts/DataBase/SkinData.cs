using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkinData 
{
    public enum ITEM_CATEGORIES
    {
        COSMETIC,
        BONUS,
    }

    public enum ColorSkin
    {
        Orange,
        Rouge,
        Bleu,
    }

    //public string ID { get => string.Format("{{0}_{1}", label[..3], price); }

    public string label;
    public string caption;

    public ITEM_CATEGORIES category;
    public ColorSkin color; 
    public Sprite sprite;
    //public Sprite icon;
    //public Color colorSkin;

    //public bool hasSpecialBonus;
    //public int Bonuslife;
    //public int availableBonusLives;

    public int price;

    public bool buyable = true;

    public bool available;

    public bool onPlayer;

    
}
