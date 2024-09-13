using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int currentCurrency = 0; // Aktuelles Guthaben
    public TextMeshProUGUI currencyText; // Textfeld, um die Währung anzuzeigen

    private void Start()
    {
        UpdateCurrencyUI();
    }

    // Funktion zum Hinzufügen von Währung
    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        UpdateCurrencyUI();
    }

    // Funktion zum Ausgeben von Währung
    public bool SpendCurrency(int amount)
    {
        if (currentCurrency >= amount)
        {
            currentCurrency -= amount;
            UpdateCurrencyUI();
            return true;
        }
        else
        {
            Debug.Log("Nicht genug Währung!");
            return false;
        }
    }

    // Aktualisiere das UI, um den aktuellen Stand anzuzeigen
    private void UpdateCurrencyUI()
    {
        currencyText.text = "Münzen: " + currentCurrency;
    }
}
