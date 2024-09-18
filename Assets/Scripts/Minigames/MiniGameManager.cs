using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{public GameObject memoryGameCanvas; // Assign this in the editor

public void StartMemoryGame()
{
    Debug.Log("Starting Memory Game...");
    memoryGameCanvas.SetActive(true); // Enable the Memory Game Canvas
}

    public void StartPlaceholder2()
    {
        Debug.Log("Starting Placeholder 2...");
    }

    public void StartPlaceholder3()
    {
        Debug.Log("Starting Placeholder 3...");
    }

    public void StartPlaceholder4()
    {
        Debug.Log("Starting Placeholder 4...");
    }
}
