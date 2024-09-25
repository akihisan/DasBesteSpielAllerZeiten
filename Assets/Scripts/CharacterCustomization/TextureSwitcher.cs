using UnityEngine;
using UnityEngine.UI;

public class TextureSwitcher : MonoBehaviour
{
    // Materialien mit den verschiedenen Texturen
    public Material material1; // Die erste Textur/Material
    public Material material2; // Die zweite Textur/Material

    // Das Renderer-Objekt deines Modells
    private Renderer modelRenderer;

    // UI-Buttons
    public Button button1; // Button für die erste Textur
    public Button button2; // Button für die zweite Textur

    void Start()
    {
        // Renderer des Modells holen
        modelRenderer = GetComponent<Renderer>();

        // Button-Listener hinzufügen
        button1.onClick.AddListener(ApplyMaterial1);
        button2.onClick.AddListener(ApplyMaterial2);
    }

    // Methode zum Wechseln auf Material 1
    void ApplyMaterial1()
    {
        modelRenderer.material = material1;
    }

    // Methode zum Wechseln auf Material 2
    void ApplyMaterial2()
    {
        modelRenderer.material = material2;
    }
}
