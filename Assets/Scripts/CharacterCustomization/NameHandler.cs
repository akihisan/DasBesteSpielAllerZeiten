using UnityEngine;
using UnityEngine.UI;

public class NameHandler : MonoBehaviour
{
    public InputField nameInputField;
    public string playerName;

    // Diese Methode wird aufgerufen, wenn der Name im Input Field geändert wird
    public void OnNameInputChanged()
    {
        // Holen den aktuellen Namen aus dem InputField
        playerName = nameInputField.text;

        // Prüfen, ob die Länge 20 Zeichen überschreitet (dies sollte durch die Zeichenbeschränkung ohnehin nicht passieren)
        if (playerName.Length > 20)
        {
            playerName = playerName.Substring(0, 20);
            nameInputField.text = playerName; // Stelle sicher, dass nur maximal 20 Zeichen angezeigt werden
        }
    }
}
