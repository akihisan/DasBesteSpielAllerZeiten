using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CurrencyManager : MonoBehaviour
{
    public InventoryScriptable inventory; //Hier steht aktuelles Geld des Spielers
    public TextMeshProUGUI currencyText; // Textfeld, um die Währung anzuzeigen

    private const float WAIT_TIMEOUT = 2f;

    public float totalPrice = 0;

    private void Start()
    {
        StartCoroutine(WaitForCurrencyText());
    }

    //Funktion um zu warten bis currencyText nicht mehr null
    private IEnumerator WaitForCurrencyText()
    {
        float startTime = Time.time;

        while (currencyText == null && Time.time - startTime < WAIT_TIMEOUT)
        {
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds before checking again
        }

        if (currencyText != null)
        {
            UpdateCurrencyUI();
        }
    }

    // Funktion zum Hinzufügen von Währung
    public void AddCurrency(float amount)
    {
        inventory.currency += amount;
        UpdateCurrencyUI();
    }

    // Funktion zum Ausgeben von Währung
    public bool SpendCurrency(float amount)
    {
        if (inventory.currency >= amount)
        {
            inventory.currency -= amount;
            totalPrice = 0;
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
        currencyText.text = "Münzen: " + inventory.currency;
    }

    public void AddToTotal(float amount)
    {
        totalPrice += amount;
    }
}
