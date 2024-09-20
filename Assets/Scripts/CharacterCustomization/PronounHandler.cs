using UnityEngine;
using UnityEngine.UI;

public class PronounHandler : MonoBehaviour
{
    public Dropdown pronounDropdown;
    public string selectedPronoun;

    // Diese Methode wird aufgerufen, wenn die Pronomen-Auswahl geändert wird
    public void OnPronounChanged()
    {
        // Auswahl aus der Dropdown-Liste holen
        selectedPronoun = pronounDropdown.options[pronounDropdown.value].text;

        // Optional: Pronomen in der Konsole ausgeben, um zu überprüfen
        Debug.Log("Selected Pronoun: " + selectedPronoun);
    }
}
