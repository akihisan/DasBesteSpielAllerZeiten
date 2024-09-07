using UnityEngine;
using UnityEngine.UI;

public class FacialFeatureSelection : MonoBehaviour
{
    // References to UI elements for facial features
    public Dropdown eyesDropdown;
    public Dropdown noseDropdown;
    public Slider mouthSlider;

    // Reference to the selected character
    private GameObject selectedCharacter;

    void Start()
    {
        // Initialize UI elements and add listeners if needed
        eyesDropdown.onValueChanged.AddListener(OnEyesChanged);
        noseDropdown.onValueChanged.AddListener(OnNoseChanged);
        mouthSlider.onValueChanged.AddListener(OnMouthChanged);
    }

    // Method to set the selected character from the previous canvas
    public void SetSelectedCharacter(GameObject character)
    {
        selectedCharacter = character;
        Debug.Log("Facial feature customization for: " + selectedCharacter.name);
    }

    // Methods to handle facial feature changes
    void OnEyesChanged(int index)
    {
        // Implement logic to update eyes on the selected character
        Debug.Log("Changed eyes to: " + eyesDropdown.options[index].text);
    }

    void OnNoseChanged(int index)
    {
        // Implement logic to update nose on the selected character
        Debug.Log("Changed nose to: " + noseDropdown.options[index].text);
    }

    void OnMouthChanged(float value)
    {
        // Implement logic to update mouth based on the slider value
        Debug.Log("Mouth slider value: " + value);
    }
}
