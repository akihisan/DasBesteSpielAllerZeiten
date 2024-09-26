using UnityEngine;
using UnityEngine.UI;

public class TextureSwitcher : MonoBehaviour
{
    // materials
    [SerializeField] private Material darkSkin;
    [SerializeField] private Material lightSkin;

    // renderer objects of all parts that change colour
    private Renderer[] modelRenderer;
    [SerializeField] private GameObject[] model;

    // current skin colour
    public string colour = "dark";


    void Start()
    {
        //make renderer array same length as model array
        modelRenderer = new Renderer[model.Length];

        // get renderers of each part
        for (int i = 0; i < model.Length; i++)
        {
            modelRenderer[i] = model[i].GetComponent<Renderer>();
        }
    }

    public void ApplyDarkSkin()
    {
        //change all materials to dark colour
        for (int i = 0; i < model.Length; i++)
        {
            modelRenderer[i].material = darkSkin;
        }
        //save current colour
        colour = "dark";
    }

    public void ApplyLightSkin()
    {
        //change all materials to light colour
        for (int i = 0; i < model.Length; i++)
        {
            modelRenderer[i].material = lightSkin;
        }
        //save colour
        colour = "light";
    }
}
