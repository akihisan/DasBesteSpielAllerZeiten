using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Der Text, der den Dialog anzeigt
    public Text dialogText;

    // Name der Person im Haus
    public string personName = "NPC";

    // Start wird aufgerufen, wenn die Szene geladen wurde
    void Start()
    {
        // Zeige den Dialog an, wenn die Szene startet
        ShowDialog();
    }

    // Funktion, um den Dialog zu starten
    public void ShowDialog()
    {
        // Placeholder-Dialog: "Hallo NAME!"
        dialogText.text = $"Hallo {personName}!";
    }
}
