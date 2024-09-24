using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopOffer", menuName = "ScriptableObjects/ShopOfferScriptable", order = 1)]
public class ShopOfferScriptable : ScriptableObject
{
    public Sprite[] foods;
    public Sprite[] clothes;
}
