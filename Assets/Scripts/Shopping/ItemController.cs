using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemController : MonoBehaviour, IPointerClickHandler
{
    public GameObject shoppingCartPanel; // Das Panel, das den Einkaufswagen darstellt.
    public Vector2 shopImageSize = new Vector2(100, 100); // Größe der Bilder im Einkaufswagen.

    // Dictionary zur Nachverfolgung der Anzahl jedes Items im Warenkorb
    private Dictionary<Sprite, GameObject> cartItems = new Dictionary<Sprite, GameObject>();

    public void OnPointerClick(PointerEventData eventData)
    {
        Sprite clickedSprite = GetComponent<Image>().sprite;

        // Prüfe, ob das Item bereits im Warenkorb ist
        if (cartItems.ContainsKey(clickedSprite))
        {
            GameObject existingItem = cartItems[clickedSprite];

            if (existingItem.activeSelf)
            {
                // Erhöhe die Anzahl und aktualisiere die Anzeige
                Text countText = existingItem.GetComponentInChildren<Text>();
                int currentCount = int.Parse(countText.text.Replace("x", ""));
                currentCount++;
                countText.text = currentCount + "x";
            }
            else
            {
                // Reaktiviere das Item und setze den Zähler auf 1
                existingItem.SetActive(true);
                Text countText = existingItem.GetComponentInChildren<Text>();
                countText.text = "1x";
            }
        }
        else
        {
            // Erstelle ein neues GameObject für das Item im Warenkorb
            GameObject newItem = new GameObject("CartItem");
            newItem.transform.SetParent(shoppingCartPanel.transform, false); // Setze den Eltern-Transform auf das Panel.

            // Füge ein Image-Komponente hinzu und setze das Sprite auf das des geklickten Items.
            Image imageComponent = newItem.AddComponent<Image>();
            imageComponent.sprite = clickedSprite;

            // Passe die Größe des neuen Items an
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.sizeDelta = shopImageSize;

            // Erstelle einen Text, der die Anzahl anzeigt
            GameObject textObj = new GameObject("CountText");
            textObj.transform.SetParent(newItem.transform, false); // Text dem Item zuordnen
            Text countText = textObj.AddComponent<Text>();
            countText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            countText.fontSize = 48;
            countText.color = Color.black;
            countText.alignment = TextAnchor.MiddleRight;
            countText.text = "1x";

            // Positioniere den Text neben dem Bild
            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(1, 0.5f); // An der rechten Seite zentriert
            textRect.anchorMax = new Vector2(1, 0.5f);
            textRect.anchoredPosition = new Vector2(50, 0); // Verschiebung nach rechts

            // Speichere das neue Item im Dictionary
            cartItems[clickedSprite] = newItem;
        }
    }

    // Diese Methode kann auf den Button gesetzt werden, um alle Items zu deaktivieren
    public void ClearCart()
    {
        foreach (var item in cartItems.Values)
        {
            item.SetActive(false); // Deaktiviert jedes Item im Einkaufswagen
        }
    }
}
