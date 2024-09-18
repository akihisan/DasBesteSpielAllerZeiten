using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGame : MonoBehaviour
{
    public List<Sprite> cardImages; // List of card images (must have pairs)
    public GameObject cardPrefab; // Prefab of the card
    public Transform gridParent; // The parent (MemoryGamePanel) where cards will be instantiated
    private List<GameObject> cards = new List<GameObject>(); // Track instantiated cards
    private GameObject firstCard, secondCard; // Track the two selected cards
    private bool canClick = true;

    void Start()
    {
        SetupCards();
    }

    void SetupCards()
    {
        // Create a list of image pairs
        List<Sprite> imagesToUse = new List<Sprite>();
        foreach (var img in cardImages)
        {
            imagesToUse.Add(img);
            imagesToUse.Add(img); // Add each image twice (to create pairs)
        }

        // Shuffle the list
        for (int i = 0; i < imagesToUse.Count; i++)
        {
            Sprite temp = imagesToUse[i];
            int randomIndex = Random.Range(0, imagesToUse.Count);
            imagesToUse[i] = imagesToUse[randomIndex];
            imagesToUse[randomIndex] = temp;
        }

        // Instantiate card buttons in the grid
        for (int i = 0; i < imagesToUse.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, gridParent);
            newCard.GetComponent<Card>().Setup(imagesToUse[i], this);
            cards.Add(newCard);
        }
    }

    // This method gets called by each card when clicked
    public void CardClicked(GameObject selectedCard)
    {
        if (!canClick) return;

        if (firstCard == null)
        {
            firstCard = selectedCard;
            firstCard.GetComponent<Card>().Reveal();
        }
        else if (secondCard == null)
        {
            secondCard = selectedCard;
            secondCard.GetComponent<Card>().Reveal();
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        canClick = false;

        // Wait for 1 second so the player can see both revealed cards
        yield return new WaitForSeconds(1f);

        if (firstCard.GetComponent<Card>().cardImage == secondCard.GetComponent<Card>().cardImage)
        {
            // Cards match, disable them
            firstCard.SetActive(false);
            secondCard.SetActive(false);
        }
        else
        {
            // Cards don't match, hide them again
            firstCard.GetComponent<Card>().Hide();
            secondCard.GetComponent<Card>().Hide();
        }

        // Reset the selected cards
        firstCard = null;
        secondCard = null;
        canClick = true;
    }
}
