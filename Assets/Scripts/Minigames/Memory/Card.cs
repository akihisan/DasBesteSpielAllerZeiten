using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite cardImage; // The image on the card
    private Sprite backImage; // The default back of the card
    private Image imageComponent;
    private MemoryGame memoryGame;

    void Awake()
    {
        imageComponent = GetComponent<Image>();
        backImage = imageComponent.sprite; // Set the default back image
    }

    public void Setup(Sprite image, MemoryGame game)
    {
        cardImage = image;
        memoryGame = game;
    }

    public void OnClick()
    {
        memoryGame.CardClicked(gameObject);
    }

    public void Reveal()
    {
        imageComponent.sprite = cardImage;
    }

    public void Hide()
    {
        imageComponent.sprite = backImage;
    }
}

