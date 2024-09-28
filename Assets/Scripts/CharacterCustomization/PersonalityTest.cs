using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PersonalityTest : MonoBehaviour
{
    public Text questionText; // Assign your question text here
    private int selectedAnswer = 0;

    public void SelectAnswer(int answer)
    {
        selectedAnswer = answer;
        Debug.Log("Selected answer: " + selectedAnswer);
        // You can store the answer or proceed to the next question.
    }
}
