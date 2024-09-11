using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IPointerClickHandler
{
    public GameObject shoppingCartPanel; // Das Panel, das den Einkaufswagen darstellt.

    public void OnPointerClick(PointerEventData eventData)
    {
        // Erstelle ein neues GameObject für das Item im Einkaufswagen.
        GameObject newItem = new GameObject("CartItem");
        newItem.transform.SetParent(shoppingCartPanel.transform, false); // Setze den Eltern-Transform auf das Panel.

        // Füge ein Image-Komponente hinzu und setze das Sprite auf das des geklickten Items.
        Image imageComponent = newItem.AddComponent<Image>();
        imageComponent.sprite = GetComponent<Image>().sprite;

        // Optional: Größe und Aussehen des neuen Items anpassen.
        RectTransform rectTransform = newItem.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(100, 100); // Beispielgröße.
    }
}
