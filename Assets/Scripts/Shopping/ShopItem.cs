using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [Tooltip("Der Preis des Items. Muss im Inspector gesetzt werden.")]
    public int itemPrice; // Preis der Kleidung, keine Initialisierung hier!

    public CurrencyManager currencyManager; // Referenz zum Currency Manager
    public Button buyButton; // Der Button, der den Kauf initiiert

    private void Start()
    {
        // Überprüfen, ob der Preis im Inspector gesetzt wurde
        if (itemPrice <= 0)
        {
            Debug.LogError("Item-Preis nicht gesetzt oder ist ungültig! Setze den Preis im Inspector für das Item: " + gameObject.name);
        }

        // Button-Klick-Event mit der Kauf-Funktion verbinden
        buyButton.onClick.AddListener(BuyItem);
    }

    // Funktion, die ausgeführt wird, wenn der Button geklickt wird
    void BuyItem()
    {
        // Versuche die Währung auszugeben, falls genug vorhanden
        if (currencyManager.SpendCurrency(itemPrice))
        {
            Debug.Log("Item gekauft für " + itemPrice + " Münzen!");
            // Hier kannst du den Code hinzufügen, um die Kleidung hinzuzufügen.
        }
        else
        {
            Debug.Log("Nicht genug Münzen! Preis des Items: " + itemPrice);
        }
    }
}
