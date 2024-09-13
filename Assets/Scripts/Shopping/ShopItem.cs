using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public int itemPrice = 10; // Preis der Kleidung
    public CurrencyManager currencyManager; // Referenz zum Currency Manager
    public Button buyButton; // Der Button, der den Kauf initiiert

    private void Start()
    {
        // Button-Klick-Event mit der Kauf-Funktion verbinden
        buyButton.onClick.AddListener(BuyItem);
    }

    // Funktion, die ausgeführt wird, wenn der Button geklickt wird
    void BuyItem()
    {
        // Versuche die Währung auszugeben, falls genug vorhanden
        if (currencyManager.SpendCurrency(itemPrice))
        {
            // Erfolg! Item kann gekauft werden.
            Debug.Log("Item gekauft!");
            // Hier kannst du den Code hinzufügen, um die Kleidung hinzuzufügen.
        }
        else
        {
            // Fehler! Nicht genug Währung.
            Debug.Log("Nicht genug Münzen!");
        }
    }
}
