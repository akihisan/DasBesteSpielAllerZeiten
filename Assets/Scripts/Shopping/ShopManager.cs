using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    // Key zum Speichern des letzten Update-Datums
    private const string LastUpdateKey = "LastShopUpdate";
    public Sprite[] shopSprites; // Array of sprites to assign to images
    public Image[] shopImages; // References to the 6 Image components

    void Start()
    {
        CheckForDailyShopUpdate();
        Debug.Log($"Found {shopImages.Length} image components");
    }

    // Funktion zum Prüfen und Aktualisieren des Angebots
    void CheckForDailyShopUpdate()
    {
        // Hol das aktuelle Datum
        DateTime currentDate = DateTime.Now;

        // Überprüfe, ob ein Datum für das letzte Update existiert
        if (PlayerPrefs.HasKey(LastUpdateKey))
        {
            // Hole das zuletzt gespeicherte Datum
            string lastUpdateString = PlayerPrefs.GetString(LastUpdateKey);
            DateTime lastUpdateDate = DateTime.Parse(lastUpdateString);

            // Überprüfe, ob ein neuer Tag begonnen hat
            if (currentDate.Date > lastUpdateDate.Date)            
            {
                UpdateShopInventory();
            }
        }
        else
        {
            // Falls es noch kein gespeichertes Datum gibt, initialisiere das Shop-Angebot
            UpdateShopInventory();
        }
    }

    // Funktion zum Aktualisieren des Shop-Angebots
    void UpdateShopInventory()
    {
        // Hier kannst du dein Shop-Angebot aktualisieren (zufällig oder mit einer Liste)
        Debug.Log("Shop-Angebot aktualisiert!");

        // Generate unique random numbers
        List<int> randomNumbers = GenerateUniqueRandomNumbers(6, 7);
        Debug.Log($"Generated numbers: {string.Join(", ", randomNumbers)}");

        // Assign sprites to images based on random numbers
        AssignSprites(randomNumbers);

        // Speichere das heutige Datum als letztes Update
        PlayerPrefs.SetString(LastUpdateKey, DateTime.Now.ToString());
        PlayerPrefs.Save();
    }

    List<int> GenerateUniqueRandomNumbers(int count, int maxNumber)
    {
        List<int> numbers = Enumerable.Range(0, maxNumber + 1).ToList();
        List<int> randomNumbers = new List<int>();

        for (int i = 0; i < count && numbers.Count > 0; i++)
        {
            int index = UnityEngine.Random.Range(0, numbers.Count);
            randomNumbers.Add(numbers[index]);
            numbers.RemoveAt(index);
        }
        Debug.Log($"Generated {randomNumbers.Count} unique numbers");
        return randomNumbers;
    }

    void AssignSprites(List<int> numbers)
    {
        Debug.Log($"Attempting to assign {numbers.Count} sprites");
        for (int i = 0; i < numbers.Count && i < shopImages.Length; i++)
        {
            Debug.Log($"Assigning sprite {i}: shopSprites[{numbers[i]}]");
            if (numbers[i] >= shopSprites.Length)
            {
                Debug.LogError($"Sprite index {numbers[i]} is out of bounds");
                continue;
            }
            shopImages[i].sprite = shopSprites[numbers[i]];
        }
    }
}

