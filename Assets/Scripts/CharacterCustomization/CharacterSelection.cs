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
        
        // Hide character selection canvas and show facial feature canvas
        characterSelectionCanvas.SetActive(false);
        facialFeatureCanvas.SetActive(true);

        // Spawn the selected character in the facial feature canvas
        SpawnSelectedCharacter();
    }

    // Method to spawn the selected character in the facial feature canvas
    void SpawnSelectedCharacter()
    {
        // Find the CharacterHolder in the FacialFeatureCanvas
        GameObject characterHolder = facialFeatureCanvas.transform.Find("CharacterHolder").gameObject;
        
        // Instantiate the selected character as a child of CharacterHolder
        Instantiate(selectedCharacterPrefab, characterHolder.transform);
    }
}
