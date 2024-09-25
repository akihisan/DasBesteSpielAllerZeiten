using UnityEngine;
using UnityEngine.UI;

public class TextureSwitcher : MonoBehaviour
{
    // Materialien mit den verschiedenen Texturen
    public Material darkSkin;
    public Material lightSkin;

    // Das Renderer-Objekt deines Modells
    private Renderer modelRenderer;


    void Start()
    {
        // Renderer des Modells holen
        modelRenderer = GetComponent<Renderer>();

    }

    // Methode zum Wechseln auf Material 1
    public void ApplyDarkSkin()
    {
        modelRenderer.material = darkSkin;
    }

    // Methode zum Wechseln auf Material 2
    public void ApplyLightSkin()
    {
        modelRenderer.material = lightSkin;
    }
}
