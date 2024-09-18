using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ItemController : MonoBehaviour, IPointerClickHandler
{
    public GameObject shoppingCartPanel; // Das Panel, das den Einkaufswagen darstellt.
    public Vector2 shopImageSize = new Vector2(100, 100); // Größe der Bilder im Einkaufswagen.
    public TextMeshProUGUI totalPriceText;
    public CurrencyManager currencyManager;
    public InventoryScriptable inventory;

    // Struct zur Speicherung von Item-Daten
    [System.Serializable]
    public struct ItemDetails
    {
        public string name;
        public Sprite image;
        public float price;
    }

    // Dictionary zur Nachverfolgung der Anzahl und Preis jedes Items im Warenkorb
    private Dictionary<ItemDetails, GameObject> cartItems = new Dictionary<ItemDetails, GameObject>();

    // Liste aller verfügbaren Items mit Preisen
    public List<ItemDetails> availableItems;

    public void OnPointerClick(PointerEventData eventData)
    {
        Image clickedImage = GetComponent<Image>();
        Sprite clickedSprite = clickedImage.sprite;
        ItemDetails itemDetails = GetItemDetails(clickedSprite);

        if (itemDetails.image != null)
        {
            // Prüfe, ob das Item bereits im Warenkorb ist
            if (cartItems.ContainsKey(itemDetails))
            {
                GameObject existingItem = cartItems[itemDetails];

                if (existingItem.activeSelf)
                {
                    // Erhöhe die Anzahl und aktualisiere die Anzeige
                    UpdateItemCount(existingItem, itemDetails.price);
                }
                else
                {
                    // Reaktiviere das Item und setze den Zähler auf 1
                    existingItem.SetActive(true);
                    ResetItemCount(existingItem, itemDetails.price);
                }
            }
            else
            {
                GameObject newItem = CreateCartItem(itemDetails);
                cartItems.Add(itemDetails, newItem);
            }
            currencyManager.AddToTotal(itemDetails.price);
            UpdateTotalPrice();
        }
       
    }

    private ItemDetails GetItemDetails(Sprite sprite)
    {
        foreach (var item in availableItems)
        {
            if (item.image == sprite)
            {
                return item;
            }
        }
        return new ItemDetails(); // Return empty struct if not found
    }

    private void UpdateItemCount(GameObject itemObject, float price)
    {
        TextMeshProUGUI countText = itemObject.GetComponentInChildren<TextMeshProUGUI>();
        string[] parts = countText.text.Split(' ');
        int currentCount = int.Parse(parts[0].Replace("x", ""));
        currentCount++;
        countText.text = $"{currentCount}x {price:C}";
    }

    private void ResetItemCount(GameObject itemObject, float price)
    {
        TextMeshProUGUI countText = itemObject.GetComponentInChildren<TextMeshProUGUI>();
        countText.text = $"1x {price:C}";
    }

    private GameObject CreateCartItem(ItemDetails itemDetails)
    {
        GameObject newItem = new GameObject("CartItem");
        newItem.transform.SetParent(shoppingCartPanel.transform, false); // Setze den Eltern-Transform auf das Panel.

        Image imageComponent = newItem.AddComponent<Image>();
        imageComponent.sprite = itemDetails.image;

        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        rectTransform.sizeDelta = shopImageSize;

        // Erstelle einen Text, der die Anzahl und Preis anzeigt
        GameObject textObj = new GameObject("CountText");
        textObj.transform.SetParent(newItem.transform, false); // Text dem Item zuordnen
        TextMeshProUGUI countText = textObj.AddComponent<TextMeshProUGUI>();
        countText.text = $"1x {itemDetails.price:C}";
        countText.fontSize = 32;
        countText.color = Color.black;
        countText.alignment = (TextAlignmentOptions)TextAnchor.MiddleRight;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(1, 0.5f); // An der rechten Seite zentriert
        textRect.anchorMax = new Vector2(1, 0.5f);
        textRect.anchoredPosition = new Vector2(50, 0); // Verschiebung nach rechts

        return newItem;
    }

    public void Buy()
    {
        if(inventory.currency >= currencyManager.totalPrice)
        {
            ClearCart();
            currencyManager.SpendCurrency(currencyManager.totalPrice);
        }
        else
        {
            Debug.Log("nuh uh");
        }
    }

    // Diese Methode kann auf den Button gesetzt werden, um alle Items zu deaktivieren
    public void ClearCart()
    {
        // Gehe durch alle Kinder des Einkaufswagen-Panels und deaktiviere sie
        foreach (Transform child in shoppingCartPanel.transform)
        {
            child.gameObject.SetActive(false);
        }
        totalPriceText.text = "Gesamtpreis: 0€";
    }

    private void UpdateTotalPrice()
    {
        totalPriceText.text = $"Gesamtpreis: {currencyManager.totalPrice:C}";
    }

}
