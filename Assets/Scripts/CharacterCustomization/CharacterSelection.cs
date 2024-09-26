using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    // References to character prefabs
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    // Buttons
    public Button selectButton1;
    public Button selectButton2;

    // References to Canvases
    public GameObject characterSelectionCanvas;
    public GameObject facialFeatureCanvas;

    // Variable to store the selected character prefab
    private GameObject selectedCharacterPrefab;

    //reference to texture switcher
    public TextureSwitcher ts;
    //skin colour materials 
    [SerializeField] private Material darkSkin;
    [SerializeField] private Material lightSkin;

    void Start()
    {
        facialFeatureCanvas.SetActive(false);
        // Assign button click events
        //selectButton1.onClick.AddListener(() => SelectCharacter(characterPrefab1));
        //selectButton2.onClick.AddListener(() => SelectCharacter(characterPrefab2));
    }

    // Method to handle character selection
    public void SelectCharacter(GameObject characterPrefab)
    {
        selectedCharacterPrefab = characterPrefab;
        Debug.Log("Selected Character: " + selectedCharacterPrefab.name);
        
        // Spawn the selected character in the facial feature canvas
        SpawnSelectedCharacter();

        // Hide character selection canvas and show facial feature canvas
        characterSelectionCanvas.SetActive(false);
        facialFeatureCanvas.SetActive(true);
    }

    // Method to spawn the selected character in the facial feature canvas
    void SpawnSelectedCharacter()
    {
        // Find the CharacterHolder in the FacialFeatureCanvas
        GameObject characterHolder = facialFeatureCanvas.transform.Find("CharacterHolder").gameObject;
        
        // Instantiate the selected character as a child of CharacterHolder
        Instantiate(selectedCharacterPrefab, characterHolder.transform);

        //set material to chosen skin colour
        SetSkinColour(characterHolder);
    }

    void SetSkinColour(GameObject characterHolder)
    {
        Renderer[] allRenderers = characterHolder.GetComponentsInChildren<Renderer>();

        Renderer HeadRenderer = null;
        Renderer BodyRenderer = null;

        foreach (Renderer renderer in allRenderers)
        {
            string name = renderer.name.ToLower();
            if (name.Contains("head"))
            {
                HeadRenderer = renderer;
            }
            else if (name.Contains("body"))
            {
                BodyRenderer = renderer;
            }

            if (HeadRenderer != null && BodyRenderer != null)
            {
                break; // Found both, we're done
            }
        }

        switch (ts.colour)
        {
            case "dark":
                HeadRenderer.material = darkSkin;
                BodyRenderer.material = darkSkin;
                break;
            case "light":
                HeadRenderer.material = lightSkin;
                BodyRenderer.material = lightSkin;
                break;
        }
    }
}
